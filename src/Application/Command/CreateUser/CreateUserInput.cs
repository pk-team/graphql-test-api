namespace Application.Command;

public class CreateUserInput  {
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }
}