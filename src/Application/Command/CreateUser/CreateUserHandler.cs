using Domain.Model;
using Infrastructure.Context;

namespace Application.Command;
public class CreateUserHandler : ICommandHandler {
    private readonly AppDbContext _context;
    public CreateUserHandler(AppDbContext context) {
        _context = context;
    }


    public async Task<CreateUserMutationResult> HandleAsync(CreateUserInput input) {
        await Task.CompletedTask;

        List<MutationError> errors = ValidateCreatePerson(input);

        if (errors.Any()) {
            return new CreateUserMutationResult(errors);
        }

        User person = new (input.Name, input.Email, input.Age);

        _context.Users.Add(person);
        _context.SaveChanges();

        return new CreateUserMutationResult(CreateUserDTO.FromPerson(person));
    }

    private List<MutationError> ValidateCreatePerson(CreateUserInput input) {
        List<MutationError> errors = new();

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


