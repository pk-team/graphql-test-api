#pragma warning disable CA1822

using Application.Command;

namespace API.Mutation;

public class Mutation {

    /// <summary>
    /// Create a user 
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<CreateUserMutationResult> CreateUserAsync(
        [Service] CreateUserHandler handler,
        CreateUserInput input
    ) {
        CreateUserMutationResult result = await handler.HandleAsync(input);
        return result;
    }

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<UpdateUserMutationoResult> UpdateUserAsync(
        [Service] UpdateUserHandler handler,
        UpdateUserInput input
    ) => await handler.HandleAsync(input);

    /// <summary>
    /// Delete a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<DeleteUserMutationoResult> DeleteUserAsync(
        [Service] DeleteUserHandler handler,
        DeleteUserInput input
    ) => await handler.HandleAsync(input);
}