using Application.Query;
using Domain.Model;
using Infrastructure.Context;

namespace API.Query;

public class Query {
    public static string Hello => "Hello World!";


    public static List<User> GetUsers(
        [Service] GetUsersQuery query,
        int first = 3
    ) {
        return query.Handle(first);
    }

    public static User GetUser(
        [Service] GetUserQuery query,
        Guid Id
    ) {
        return query.Handle(Id);
    }

    public static List<Client> GetClients(
        [Service] AppDbContext context,
        int first = 3
    ) {
        return context.Clients.Take(first).ToList();
    }
}