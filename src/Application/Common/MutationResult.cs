namespace Application;

public class MutationResult<T> {
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
}