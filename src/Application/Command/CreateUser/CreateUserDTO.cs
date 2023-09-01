using Domain.Model;

namespace Application.Command;

public class CreateUserDTO  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }

    // create from Person
    public static CreateUserDTO FromPerson(User person) {
        return new CreateUserDTO {
            Id = person.Id,
            Name = person.Name,
            Email = person.Email,
            Age = person.Age
        };
    }
}