namespace Domain.Model;

public class Person {
    public Guid Id { get; set;  }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
}