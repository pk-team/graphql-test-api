using Domain.Model;

namespace Application.Command;

public class UpdatePersonDTO  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }

    // create from Person
    public static UpdatePersonDTO FromPerson(Person person) {
        return new UpdatePersonDTO {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }
}