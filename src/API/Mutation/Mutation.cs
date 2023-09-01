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
    public Application.MutationResult<CreateUserDTO> CreateUser(
        [Service] Application.Command.CreatePersonHandler handler,
        CreateUserInput input
    ) {
        var result = handler.Handle(input);
        return result;
    }

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public Application.MutationResult<UpdateUserDTO> UpdateUser(
        [Service] Application.Command.UpdateUserHandler handler,
        UpdateUserInput input
    ) {
        var result = handler.Handle(input);
        return result;
    }


}