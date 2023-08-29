using Infrastructure.Context;
using Domain.Model;

namespace Application.Query;

public class GetPeopleQuery {

    // AppDbContext
    private readonly AppDbContext _context;
    public GetPeopleQuery(AppDbContext context) {
        _context = context;
    }

    public List<Person> Handle(int? first = null) {
        if (first is not null) {
            return _context.People.Take(first.Value).ToList();
        }
        return _context.People;
    }
}
