namespace Domain.Model;

public class Person {
    public Guid Id { get; private set;  }
    public string Name { get; private set; } = null!;
    public int Age { get; private  set; }

    // constructor
    public Person(string name, int age) {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }

    // update
    public void Update(string name, int age) {
        if (age < 0 || age > 100) {
            throw new ArgumentException("Age must be between 0 and 100");
        }

        Name = name;
        Age = age;
    }
}