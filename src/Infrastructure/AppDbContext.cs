using Domain.Model;

namespace Infrastructure.Context;
public class AppDbContext {

    public List<Person> People { get; set; } = new List<Person>();

    public void SaveChanges() {
        Console.WriteLine("Saving changes...");
    }

    public AppDbContext() {
        People.Add(new Person {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Age = 42
        });
        People.Add(new Person {
            Id = Guid.NewGuid(),
            Name = "Jane Doe",
            Age = 39
        });
    }
}