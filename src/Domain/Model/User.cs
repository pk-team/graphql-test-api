namespace Domain.Model;

public class User {
    public Guid Id { get; private set;  }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int Age { get; private  set; }

    // constructor
    public User(string name, string email, int age) {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Age = age;
    }

    // update
    public void Update(string name, string email, int age) {
        if (age < 0 || age > 100) {
            throw new ArgumentException("Age must be between 0 and 100");
        }

        Name = name;
        Email = email;  
        Age = age;
    }
}