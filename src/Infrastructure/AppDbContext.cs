using Domain.Model;

namespace Infrastructure.Context;
public class AppDbContext {

    public List<Person> People { get; set; } = new List<Person>();

    public void SaveChanges() {
        Console.WriteLine("Saving changes...");
    }

    public AppDbContext() {
        People.Add(new Person("Liam", 1));
        People.Add(new Person("Noah", 2));
        People.Add(new Person("Oliver", 3));
        People.Add(new Person("James", 4));
        People.Add(new Person("William", 5));
        People.Add(new Person("Benjamin", 6));
        People.Add(new Person("Alexander", 7));
        People.Add(new Person("Elijah", 8));
        People.Add(new Person("Lucas", 9));
        People.Add(new Person("Henry", 10));
    }
}