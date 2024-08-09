namespace Domain.Entities;

public class User : Person
{
    public int Id { get; set; }
    public string Password { get; set; }
    public bool Ative { get; set; }
}