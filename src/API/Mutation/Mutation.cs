using Application.Command;

namespace API.Mutation;

public class Mutation {

    /// <summary>
    /// Create a user 
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public  async Task<Application.MutationResult<CreateUserDTO>> CreateUserAsync(
        [Service] Application.Command.CreateUserHandler handler,
        CreateUserInput input
    ) {
        Application.MutationResult<CreateUserDTO> result = await handler.HandleAsync(input);
        return result;
    }

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public  async Task<Application.MutationResult<UpdateUserDTO>> UpdateUserAsync(
        [Service] UpdateUserHandler handler,
        UpdateUserInput input
    ) {
        Application.MutationResult<UpdateUserDTO> result = await handler.HandleAsync(input);
        return result;
    }

    /// <summary>
    /// Delete a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public  async Task<Application.MutationResult<DeleteUserDTO>> DeleteUserAsync(
        [Service] DeleteUserHandler handler,
        DeleteUserInput input
    ) {
        Application.MutationResult<DeleteUserDTO> result = await handler.HandleAsync(input);
        return result;
    }
}