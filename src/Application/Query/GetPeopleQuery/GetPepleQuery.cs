using Infrastructure.Context;
using Domain.Model;

namespace Application.Query;

public class GetPeopleQuery {

    // AppDbContext
    private readonly AppDbContext _context;
    public GetPeopleQuery(AppDbContext context) {
        _context = context;
    }

    public List<Person> Handle() {
        return _context.People;
    }
}
