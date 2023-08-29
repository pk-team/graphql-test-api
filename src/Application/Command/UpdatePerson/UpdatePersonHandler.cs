
using Domain.Model;
using Infrastructure.Context;

namespace Application.Command;
public class UpdatePersonHandler {
    private readonly AppDbContext _context;
    public UpdatePersonHandler(AppDbContext context) {
        _context = context;
    }

        private List<string> ValidateUpdatePerson(UpdatePersonInput input) {
        var errors = new List<string>();

        var personExists = _context.People.Any(p => p.Id == input.Id);
        if (!personExists) {
            errors.Add("Person not found");
            return errors;
        }

        var nameTaken = _context.People.FirstOrDefault(p => p.Name == input.Name && p.Id != input.Id);
        if (nameTaken != null) {
            errors.Add("Name already taken");
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


    public Application.MutationResult<UpdatePersonDTO> Handle(UpdatePersonInput input) {

        var errors = ValidateUpdatePerson(input);
        if (errors.Any()) {
            return new Application.MutationResult<UpdatePersonDTO> {
                Errors = errors
            };
        }

        var person = _context.People.First(p => p.Id == input.Id);

        person.Update(input.Name, input.Age);

        _context.People.Add(person);
        _context.SaveChanges();
        return new Application.MutationResult<UpdatePersonDTO> {
            Data = UpdatePersonDTO.FromPerson(person)
        };
    }
}
