namespace Application.Command;

public class CreateUserMutationResult: MutationResult {
    public CreateUserDTO User { get;  private set; } = null!;

    public CreateUserMutationResult(CreateUserDTO user) {
        User = user;
    }
    public CreateUserMutationResult(List<MutationError> errors) {
        Errors = errors;
    }
}