namespace Application;

public class MutationError {

    public string Path { get; set; } = null!;
    public string Message { get; set; } = null!;

    public MutationError(string message) => Message = message;
    public MutationError(string path, string message) {
        Path = path;
        Message = message;
    }
}

public static class MutationErrorExtension {
    public static void AddError(this MutationResult<object> result, string message) {
        result.Errors.Add(new MutationError(message));
    }
    public static void AddError(this MutationResult<object> result, string path, string message) {
        result.Errors.Add(new MutationError(path, message));
    }

    public static void Add(this List<MutationError> errors, string message) {
        errors.Add(new MutationError(message));
    }
    public static void Add(this List<MutationError> errors, string path, string message) {
        errors.Add(new MutationError(message));
    }
}