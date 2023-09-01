using Domain.Model;
using Infrastructure.Context;

namespace Application.Query;

public class GetUserQuery {

    // AppDbContext
    private readonly AppDbContext _context;
    public GetUserQuery(AppDbContext context) {
        _context = context;
    }

    public User Handle(Guid Id) {
        return _context.Users.First(p => p.Id == Id);
    }
}
