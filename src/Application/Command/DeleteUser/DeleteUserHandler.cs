
using Infrastructure.Context;

namespace Application.Command;
public class DeleteUserHandler : ICommandHandler {
    private readonly AppDbContext _context;
    public DeleteUserHandler(AppDbContext context) {
        _context = context;
    }

    public async Task<DeleteUserMutationoResult> HandleAsync(DeleteUserInput input) {
        await Task.CompletedTask;

        List<MutationError> errors = ValidateDeletePerson(input);
        if (errors.Any()) {
            return new DeleteUserMutationoResult(errors);
        }

        Domain.Model.User user = _context.Users.First(p => p.Id == input.Id);
        _context.Users.Remove(user);
        _context.SaveChanges();

        return new DeleteUserMutationoResult(DeleteUserDTO.FromUser(user));
    }
    private List<MutationError> ValidateDeletePerson(DeleteUserInput input) {
        List<MutationError> errors = new();

        bool personExists = _context.Users.Any(p => p.Id == input.Id);
        if (!personExists) {
            errors.Add("User not found");
            return errors;
        }

        return errors;
    }

}
