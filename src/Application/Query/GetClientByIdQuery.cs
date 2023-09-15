using Domain.Model;
using Infrastructure.Context;

namespace Application.Query;

public class GetClientQuery : IQueryHandler {

    // AppDbContext
    private readonly AppDbContext _context;
    public GetClientQuery(AppDbContext context) {
        _context = context;
    }

    public Client Handle(Guid Id) {
        return _context.Clients.First(p => p.Id == Id);
    }
}
