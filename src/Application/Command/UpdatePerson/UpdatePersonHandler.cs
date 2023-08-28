
using Infrastructure.Context;
using Domain.Model;

namespace Application.Command;
public class UpdatePersonHandler {
    private readonly AppDbContext _context;
    public UpdatePersonHandler(AppDbContext context) {
        _context = context;
    }

    public Application.MutationResult<UpdatePersonDTO> Handle(UpdatePersonInput input) {

        // get existing person
        var person = _context.People.FirstOrDefault(p => p.Id == input.Id);
        // error if not found
        if (person == null) {
            return new Application.MutationResult<UpdatePersonDTO> {
                Errors = new List<string> { "Person not found" }
            };
        }

        // name in use by another ID
        var existing = _context.People.FirstOrDefault(p => p.Name == input.Name && p.Id != input.Id);
        // error
        if (existing != null) {
            return new Application.MutationResult<UpdatePersonDTO> {
                Errors = new List<string> { "Person already exists" }
            };
        }

        // update person
        person.Name = input.Name;
        person.Age = input.Age;

        _context.People.Add(person);
        _context.SaveChanges();
        return new Application.MutationResult<UpdatePersonDTO> {
            Data = UpdatePersonDTO.FromPerson(person)
        };
    }
}
