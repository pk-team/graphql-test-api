namespace Domain.Model;

public class Client {
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string TaxID { get; set; } = null!;
    public string PaymentTerms { get; set; } = null!;

    // constructor
    public Client(string name, string email, string address, string phone, string taxID, string paymentTerms) {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Address = address;
        Phone = phone;
        TaxID = taxID;
        PaymentTerms = paymentTerms;
    }

    // update
    public void Update(string name, string email, string address, string phone, string taxID, string paymentTerms) {
        Name = name;
        Email = email;
        Address = address;
        Phone = phone;
        TaxID = taxID;
        PaymentTerms = paymentTerms;
    }
}

