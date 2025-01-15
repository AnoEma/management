using Infrastructure.Repository.Users.Commands;

namespace Application.UseCases.Users.Commands;

public record UserCommand
(
    int Id,
    string Name,
    string LastName,
    string Email,
    string Phone,
    string Cpf,
    string BirthDate,
    int Gender,
    int ProfileAccess,
    string User,
    int Team
)
{
    public static User CreateUserCommandToUser(UserCommand command)
    {
        return new()
        {
            Id = command.Id,
            FirstName = command.Name,
            LastName = command.LastName,
            Email = command.Email,
            PhoneNumber = command.Phone,
            Cpf = command.Cpf,
            BirthDate = DateTime.Parse(command.BirthDate),
            Gender = command.Gender,
            AccessLevel = command.ProfileAccess,
            Username = command.User,
            TeamName = command.Team,
            IsActive = true
        };
    }

    internal static UserCommand ConvertUserToUserCommand(User value)
    {
        return new(
            Id: value.Id,
            Name: value.FirstName,
            LastName: value.LastName,
            Email: value.Email,
            Phone: value.PhoneNumber,
            Cpf: value.Cpf,
            BirthDate: value.BirthDate.ToString("yyyy-MM-dd"),
            Gender: value.Gender,
            ProfileAccess: value.AccessLevel,
            User: value.Username,
            Team: value.TeamName);
    }
};
