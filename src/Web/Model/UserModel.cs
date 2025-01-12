using Application.UseCases.Users.Commands;

namespace Web.Model;

public class UserModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
    public int Gender { get; set; }
    public int ProfileAccess { get; set; }
    public string User { get; set; }
    public int Team { get; set; }

    internal static CreateUserCommand CreateUserCommand(UserModel user)
    {
        return new(
            Name: user.Name,
            LastName: user.LastName,
            Email: user.Email,
            Phone: user.Phone,
            Cpf: user.Cpf,
            user.BirthDate.ToString("yyyy-MM-dd"),
            Gender: user.Gender,
            ProfileAccess: user.ProfileAccess,
            User: user.User,
            Team: user.Team
        );
    }
}