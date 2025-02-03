using Application.UseCases.Users.Commands;
using System.ComponentModel.DataAnnotations;

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

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    internal static UserCommand CreateUserCommand(UserModel user, string userIdentityId = null)
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
            Team: user.Team,
            IdentityId: userIdentityId
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

public class LoginModel
{
    public string User { get; set; }
    public string Password { get; set; }
}

public record UserLoginModel
(
    string IdentityId
);