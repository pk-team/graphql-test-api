using Domain.Model;

namespace Application.Command;

public class DeleteUserDTO {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    // create from User
    public static DeleteUserDTO FromUser(User user) {
        return new DeleteUserDTO {
            Id = user.Id,
            Name = user.Name
        };
    }
}