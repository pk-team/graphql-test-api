using API.Mutation;

namespace Application.Command;

public class DeleteUserMutationoResult: MutationResult {
    public DeleteUserDTO? User { get;  private set; } = null!;

    public DeleteUserMutationoResult(DeleteUserDTO user) {
        User = user;
    }
    public DeleteUserMutationoResult(List<MutationError> errors) {
        Errors = errors;
    }
}