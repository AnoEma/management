namespace Infrastructure.Repository.Users.Commands;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
    public int Gender { get; set; }
    public int AccessLevel { get; set; }
    public string Username { get; set; }
    public int TeamName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime AdmissionDate { get; set; }
    public DateTime? DateDismissal { get; set; } = null;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? DeleteIn { get; set; } = null;
}