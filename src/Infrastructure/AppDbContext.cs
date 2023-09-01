using Domain.Model;

namespace Infrastructure.Context;
public class AppDbContext {

    public List<User> People { get; set; } = new List<User>();

    public void SaveChanges() {
        Console.WriteLine("Saving changes...");
    }

    public AppDbContext() {
        People.Add(new User("Liam", "liam@gmail.com", 1));
        People.Add(new User("Noah", "noah@gmail.com", 2));
        People.Add(new User("Oliver", "oliver@gmail.com", 3));
        People.Add(new User("James", "james@gmail.com", 4));
        People.Add(new User("William", "william@gmail.com", 5));
        People.Add(new User("Benjamin", "benjamin@gmail.com", 6));
        People.Add(new User("Alexander", "alexander@gmail.com", 7));
        People.Add(new User("Elijah", "elijah@gmail.com", 8));
        People.Add(new User("Lucas", "lucas@gmail.com", 9));
        People.Add(new User("Henry", "henry@gmail.com", 10));
    }
}