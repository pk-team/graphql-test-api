namespace Application.Query;

public class GetClientsByNameDTO {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}