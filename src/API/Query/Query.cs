using Application.Query;
using Domain.Model;
using Infrastructure.Context;

namespace API.Query;

public class Query {
    public string Hello => "Hello World!";


    public List<User> GetUsers(
        [Service] GetUsersQuery query,
        int first = 3
    ) {
        return query.Handle(first);
    }

    public User GetPerson(
        [Service] GetUserQuery query,
        Guid Id
    ) {
        return query.Handle(Id);
    }
}