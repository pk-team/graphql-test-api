using Domain.Model;
using Infrastructure.Context;

namespace Application.Command;
public class UpdateUserHandler : ICommandHandler {
    private readonly AppDbContext _context;
    public UpdateUserHandler(AppDbContext context) {
        _context = context;
    }

    public async Task<UpdateUserMutationoResult> HandleAsync(UpdateUserInput input) {
        await Task.CompletedTask;

        List<MutationError> errors = ValidateUpdatePerson(input);
        if (errors.Any()) {
            return new UpdateUserMutationoResult(errors);
        }

        User user = _context.Users.First(p => p.Id == input.Id);
        user.Update(input.Name, input.Email, input.Age);

        _context.SaveChanges();

        return new UpdateUserMutationoResult(UpdateUserDTO.FromUser(user));
    }

    private List<MutationError> ValidateUpdatePerson(UpdateUserInput input) {
        var errors = new List<MutationError>();

        var personExists = _context.Users.Any(p => p.Id == input.Id);
        if (!personExists) {
            errors.Add("Person not found");
            return errors;
        }

        var nameTaken = _context.Users.FirstOrDefault(p => p.Name == input.Name && p.Id != input.Id);
        if (nameTaken != null) {
            errors.Add("Name already taken");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(input.Email)) {
            errors.Add("Email cannot be blank");
        } else if (!input.Email.Contains('@')) {
            errors.Add("Email must contain @");
        }

        if (string.IsNullOrWhiteSpace(input.Name)) {
            errors.Add("Name cannot be blank");
        }

        if (input.Age < 0 || input.Age > 120) {
            errors.Add("Age must be between 0 and 120");
        }

        return errors;
    }
}
