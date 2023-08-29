using Domain.Model;
using Infrastructure.Context;

namespace Application.Command;
public class CreatePersonHandler {
    private readonly AppDbContext _context;
    public CreatePersonHandler(AppDbContext context) {
        _context = context;
    }

    private List<string> ValidateCreatePerson(CreatePersonInput input) {
        var errors = new List<string>();

        if (_context.People.Any(p => p.Name == input.Name)) {
            errors.Add("Person already exists");
            return errors;
        }

        if (string.IsNullOrWhiteSpace(input.Name)) {
            errors.Add("Name cannot be blank");
        }
        
        if (input.Age < 0 || input.Age > 120) {
            errors.Add("Age must be between 0 and 120");
        }

        return errors;
    }

    public Application.MutationResult<CreatePersonDTO> Handle(CreatePersonInput input) {
        var errors = ValidateCreatePerson(input);

        if (errors.Any()) {
            return new Application.MutationResult<CreatePersonDTO> {
                Errors = errors
            };
        }

        var person = new Person(input.Name, input.Age);

        _context.People.Add(person);
        _context.SaveChanges();

        return new Application.MutationResult<CreatePersonDTO> {
            Data = CreatePersonDTO.FromPerson(person)
        };
    }
}


