using Domain.Model;

namespace Application.Command;

public class UpdateUserDTO  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }

    // create from Person
    public static UpdateUserDTO FromPerson(User person) {
        return new UpdateUserDTO {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };
    }
}