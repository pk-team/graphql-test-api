using Domain.Model;

namespace Infrastructure.Context;
public class AppDbContext {

    public List<User> Users { get; set; } = new List<User>();
    public List<Client> Clients { get; set; } = new List<Client>();

    public void SaveChanges() {
        Console.WriteLine("Saving changes...");
    }

    public AppDbContext() {
        SeedUsers();
        SeedClients();
    }

    // seedclients

    private void SeedClients() {
        Clients.Add(new Client("Company 1", "acmecorp@gmail.com", "123 Main St", "New York", "NY", "10001"));
        Clients.Add(new Client("Company 2", "company2@gmail.com", "456 Elm St", "Los Angeles", "CA", "90001"));
        Clients.Add(new Client("Company 3", "company3@gmail.com", "789 Oak St", "Chicago", "IL", "60601"));
        Clients.Add(new Client("Company 4", "company4@gmail.com", "321 Pine St", "Houston", "TX", "77001"));
        Clients.Add(new Client("Company 5", "company5@gmail.com", "654 Maple St", "Miami", "FL", "33101"));
    }
    private void SeedUsers() {
        Users.Add(new User("Liam", "liam@gmail.com", 1));
        Users.Add(new User("Noah", "noah@gmail.com", 2));
        Users.Add(new User("Oliver", "oliver@gmail.com", 3));
        /*
        Users.Add(new User("James", "james@gmail.com", 4));
        Users.Add(new User("William", "william@gmail.com", 5));
        Users.Add(new User("Benjamin", "benjamin@gmail.com", 6));
        Users.Add(new User("Alexander", "alexander@gmail.com", 7));
        Users.Add(new User("Elijah", "elijah@gmail.com", 8));
        Users.Add(new User("Lucas", "lucas@gmail.com", 9));
        Users.Add(new User("Henry", "henry@gmail.com", 10));
        */
    }
}