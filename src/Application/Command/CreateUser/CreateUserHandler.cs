using Domain.Model;
using Infrastructure.Context;

namespace Application.Command;
public class CreatePersonHandler {
    private readonly AppDbContext _context;
    public CreatePersonHandler(AppDbContext context) {
        _context = context;
    }

    private List<MutationError> ValidateCreatePerson(CreateUserInput input) {
        var errors = new List<MutationError>();

        if (_context.Users.Any(p => p.Name == input.Name)) {
            errors.Add("Person name already exists");
            return errors;
        }

        if (_context.Users.Any(p => p.Email == input.Email)) {
            errors.Add("Email already exists");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(input.Name)) {
            errors.Add("Name cannot be blank");
        }

        if (string.IsNullOrWhiteSpace(input.Email)) {
            errors.Add("Email cannot be blank");
        } else if (!input.Email.Contains("@")) {
            errors.Add("Email must contain @");
        }
        
        if (input.Age < 0 || input.Age > 120) {
            errors.Add("Age must be between 0 and 120");
        }

        return errors;
    }

    public Application.MutationResult<CreateUserDTO> Handle(CreateUserInput input) {
        var errors = ValidateCreatePerson(input);

        if (errors.Any()) {
            return new Application.MutationResult<CreateUserDTO> {
                Errors = errors
            };
        }

        var person = new User(input.Name, input.Email, input.Age);

        _context.Users.Add(person);
        _context.SaveChanges();

        return new Application.MutationResult<CreateUserDTO> {
            Data = CreateUserDTO.FromPerson(person)
        };
    }
}


