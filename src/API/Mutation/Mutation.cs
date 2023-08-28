using Application.Command;
using Domain.Model;
using Infrastructure.Context;

namespace API.Mutation;

public class Mutation {


    public Application.MutationResult<CreatePersonDTO> CreatePerson(
        [Service] Application.Command.CreatePersonHandler handler,
        CreatePersonInput input
    ) {
        var result = handler.Handle(input);
        return result;
    }
    public Application.MutationResult<UpdatePersonDTO> UpdatePerson(
        [Service] Application.Command.UpdatePersonHandler handler,
        UpdatePersonInput input
    ) {
        var result = handler.Handle(input);
        return result;
    }


}