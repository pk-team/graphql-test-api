using Domain.Model;
using Infrastructure.Context;

namespace Application.Command;
public class CreateUserHandler : ICommandHandler {
    private readonly AppDbContext _context;
    public CreateUserHandler(AppDbContext context) {
        _context = context;
    }


    public async Task<MutationResult<CreateUserDTO>> HandleAsync(CreateUserInput input) {
        await Task.CompletedTask;

        List<MutationError> errors = ValidateCreatePerson(input);

        if (errors.Any()) {
            return new MutationResult<CreateUserDTO> {
                Errors = errors
            };
        }

        var person = new User(input.Name, input.Email, input.Age);

        _context.Users.Add(person);
        _context.SaveChanges();

        return new MutationResult<CreateUserDTO> {
            Data = CreateUserDTO.FromPerson(person)
        };
    }

    private List<MutationError> ValidateCreatePerson(CreateUserInput input) {
        var errors = new List<MutationError>();

        if (_context.Users.Any(p => p.Name == input.Name)) {
            errors.Add("name", "Person name already exists");
            return errors;
        }

        if (_context.Users.Any(p => p.Email == input.Email)) {
            errors.Add("email", "Email already exists");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(input.Name)) {
            errors.Add("name", "Name cannot be blank");
        }

        if (string.IsNullOrWhiteSpace(input.Email)) {
            errors.Add("email", "Email cannot be blank");
        } else if (!input.Email.Contains('@')) {
            errors.Add("email", "Email must contain @");
        }

        if (input.Age is < 0 or > 120) {
            errors.Add("age", "Age must be between 0 and 120");
        }
        
        return errors;
    }

}


