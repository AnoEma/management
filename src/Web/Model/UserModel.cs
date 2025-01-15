using Application.UseCases.Users.Commands;

namespace Web.Model;

public class UserModel
{
    public int Id { get; set; }
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

    internal static UserCommand CreateUserCommand(UserModel user)
    {
        return new(
            Id: user.Id,
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

    internal static UserModel CreateUserModel(UserCommand value)
    {
        return new()
        {
            Id = value.Id,
            Name = value.Name,
            LastName = value.LastName,
            Email = value.Email,
            Phone = value.Phone,
            Cpf = value.Cpf,
            BirthDate = DateTime.Parse(value.BirthDate),
            Gender = value.Gender,
            ProfileAccess = value.ProfileAccess,
            User = value.User,
            Team = value.Team
        };
    }
}