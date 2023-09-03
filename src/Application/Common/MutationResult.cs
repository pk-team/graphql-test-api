namespace Application;

public class MutationResult<T> {
    public T? Data { get; set; }
    public List<MutationError> Errors { get; set; } = new List<MutationError>();
}