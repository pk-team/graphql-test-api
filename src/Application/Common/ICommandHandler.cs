namespace Application.Command;

public interface ICommandHandler<TInput, TOutput> {
    Task<Application.MutationResult<TOutput>> HandleAsync(TInput input);
}