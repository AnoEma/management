namespace Domain.Entities;

public class Customer: Person
{
    public int Id { get; set; }
    public string Address { get; set; }
    public Vehicle Vehicle { get; set; }
}