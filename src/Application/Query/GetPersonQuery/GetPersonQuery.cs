using Domain.Model;
using Infrastructure.Context;

namespace Application.Query;

public class GetPersonQuery {

    // AppDbContext
    private readonly AppDbContext _context;
    public GetPersonQuery(AppDbContext context) {
        _context = context;
    }

    public Person Handle(Guid Id) {
        return _context.People.First(p => p.Id == Id);
    }
}
