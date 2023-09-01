using Domain.Model;

namespace Infrastructure.Context;
public class AppDbContext {

    public List<User> Users { get; set; } = new List<User>();

    public void SaveChanges() {
        Console.WriteLine("Saving changes...");
    }

    public AppDbContext() {
        Users.Add(new User("Liam", "liam@gmail.com", 1));
        Users.Add(new User("Noah", "noah@gmail.com", 2));
        Users.Add(new User("Oliver", "oliver@gmail.com", 3));
        Users.Add(new User("James", "james@gmail.com", 4));
        Users.Add(new User("William", "william@gmail.com", 5));
        Users.Add(new User("Benjamin", "benjamin@gmail.com", 6));
        Users.Add(new User("Alexander", "alexander@gmail.com", 7));
        Users.Add(new User("Elijah", "elijah@gmail.com", 8));
        Users.Add(new User("Lucas", "lucas@gmail.com", 9));
        Users.Add(new User("Henry", "henry@gmail.com", 10));
    }
}