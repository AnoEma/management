using Infrastructure.Repository.Users.Commands;

namespace Application.UseCases.Users.Commands;

public record CreateUserCommand
(
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
    public static User CreateUserCommandToUser(CreateUserCommand command)
    {
        return new()
        {
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
};
