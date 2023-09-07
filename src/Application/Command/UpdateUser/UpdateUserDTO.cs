using Domain.Model;

namespace Application.Command;

public class UpdateUserDTO  {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }

    // create from Person
    public static UpdateUserDTO FromUser(User user) {
        return new UpdateUserDTO {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age
        };
    }
}