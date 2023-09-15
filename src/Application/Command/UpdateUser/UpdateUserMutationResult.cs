using API.Mutation;

namespace Application.Command;

public class UpdateUserMutationoResult: MutationResult {
    public UpdateUserDTO? User { get;  private set; } = null!;

    public UpdateUserMutationoResult(UpdateUserDTO user) {
        User = user;
    }
    public UpdateUserMutationoResult(List<MutationError> errors) {
        Errors = errors;
    }
}