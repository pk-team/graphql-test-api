using Infrastructure.Context;
using Domain.Model;

namespace Application.Command;
public class CreatePersonHandler {
    private readonly AppDbContext _context;
    public CreatePersonHandler(AppDbContext context) {
        _context = context;
    }

    public Application.MutationResult<CreatePersonDTO> Handle(CreatePersonInput input) {

        if (_context.People.Any(p => p.Name == input.Name)) {
            return new Application.MutationResult<CreatePersonDTO> {
                Errors = new List<string> { "Person already exists" }
            };
        }

        if (string.IsNullOrWhiteSpace(input.Name)) {
            return new Application.MutationResult<CreatePersonDTO> {
                Errors = new List<string> { "Name cannot be blank" }
            };
        }
        
        if (input.Age < 0 || input.Age > 120) {
            return new Application.MutationResult<CreatePersonDTO> {
                Errors = new List<string> { "Age must be between 0 and 120" }
            };
        }

        var person = new Person {
            Id = Guid.NewGuid(),
            Name = input.Name,
            Age = input.Age
        };

        _context.People.Add(person);
        _context.SaveChanges();
        return new Application.MutationResult<CreatePersonDTO> {
            Data = CreatePersonDTO.FromPerson(person)
        };
    }
}
