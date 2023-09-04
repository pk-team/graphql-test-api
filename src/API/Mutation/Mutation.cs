using Application.Command;
using Domain.Model;
using Infrastructure.Context;

namespace API.Mutation;

public class Mutation {

    /// <summary>
    /// Create a user 
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Application.MutationResult<CreateUserDTO>> CreateUser(
        [Service] Application.Command.CreateUserHandler handler,
        CreateUserInput input
    ) {
        var result =await  handler.HandleAsync(input);
        return result;
    }

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Application.MutationResult<UpdateUserDTO>> UpdateUserAsync(
        [Service] Application.Command.UpdateUserHandler handler,
        UpdateUserInput input
    ) {
        var result = await handler.HandleAsync(input);
        return result;
    }

    /// <summary>
    /// Delete a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Application.MutationResult<DeleteUserDTO>> DeleteUserAsync(
        [Service] Application.Command.DeleteUserHandler handler,
        DeleteUserInput input
    ) {
        var result = await handler.HandleAsync(input);
        return result;
    }
}