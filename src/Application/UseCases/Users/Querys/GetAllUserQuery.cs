using Infrastructure.Repository.Users.Commands;

namespace Application.UseCases.Users.Querys;

public record GetAllUserQuery
(
    int Id,
    string FirstName,
    string LastName,
    string Username,
    int TeamName,
    bool IsActive
)
{
    internal static IReadOnlyList<GetAllUserQuery> CreateUserQueryList(List<User> value)
    {
        List<GetAllUserQuery> response = [];

        foreach (var item in value)
        {
            response.Add(new GetAllUserQuery(
                Id: item.Id,
                FirstName: item.FirstName,
                LastName: item.LastName,
                Username: item.Username,
                TeamName: item.TeamName,
                IsActive: item.IsActive
            ));
        }
        return response;
    }
};