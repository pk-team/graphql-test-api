
using Infrastructure.Context;

namespace Application.Command;
public class DeleteUserHandler : ICommandHandler {
    private readonly AppDbContext _context;
    public DeleteUserHandler(AppDbContext context) {
        _context = context;
    }



    public async Task<Application.MutationResult<DeleteUserDTO>> HandleAsync(DeleteUserInput input) {
        await Task.CompletedTask;

        var errors = ValidateDeletePerson(input);
        if (errors.Any()) {
            return new Application.MutationResult<DeleteUserDTO> {
                Errors = errors
            };
        }

        var user = _context.Users.First(p => p.Id == input.Id);

        _context.Users.Remove(user);
        _context.SaveChanges();
        return new Application.MutationResult<DeleteUserDTO> {
            Data = DeleteUserDTO.FromUser(user)
        };
    }
    private List<MutationError> ValidateDeletePerson(DeleteUserInput input) {
        var errors = new List<MutationError>();

        var personExists = _context.Users.Any(p => p.Id == input.Id);
        if (!personExists) {
            errors.Add("User not found");
            return errors;
        }

        return errors;
    }

}
