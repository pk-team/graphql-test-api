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

    public User GetUser(
        [Service] GetUserQuery query,
        Guid Id
    ) {
        return query.Handle(Id);
    }

    public List<Client> GetClients(
        [Service] AppDbContext context,
        int first = 3
    ) {
        return context.Clients.Take(first).ToList();
    }
}