using Infrastructure.Context;
using Domain.Model;

namespace Application.Query;

public class GetUsersQuery : IQueryHandler {

    // AppDbContext
    private readonly AppDbContext _context;
    public GetUsersQuery(AppDbContext context) {
        _context = context;
    }

    public List<User> Handle(int? first = null) {
        if (first is not null) {
            return _context.Users.Take(first.Value).ToList();
        }
        return _context.Users;
    }
}
