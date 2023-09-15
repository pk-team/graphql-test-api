using Infrastructure.Context;

namespace Application.Query;

public class GetClientsByNameQuery : IQueryHandler {
    private readonly AppDbContext _context;
    public GetClientsByNameQuery(AppDbContext context) {
        _context = context;
    }

    public List<GetClientsByNameDTO> Handle(string name) {
        name = name.ToLower();
        return _context.Clients.Where(c => c.Name.ToLower().Contains(name))
        .Select(c => new GetClientsByNameDTO {
            Id = c.Id,
            Name = c.Name
        })
        .ToList();
    }
}