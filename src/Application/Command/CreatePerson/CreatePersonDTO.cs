using Domain.Model;

namespace Application.Command;

public class CreatePersonDTO  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }

    // create from Person
    public static CreatePersonDTO FromPerson(Person person) {
        return new CreatePersonDTO {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }
}