using Application.UseCases.Users.Querys;

namespace Web.Model;

public record GetAllUserModel
(
    int Id,
    string Name,
    string User,
    string TeamName,
    string IsActive
)
{
    internal static IReadOnlyList<GetAllUserModel> CreateUserModelList(IReadOnlyList<GetAllUserQuery> value)
    {
        List<GetAllUserModel> userModels = [];

        foreach (GetAllUserQuery user in value)
        {
           userModels.Add(new(
               Id: user.Id,
               Name: $"{user.FirstName} {user.LastName}",
               User: user.Username,
               TeamName: GetDescriptionTeam(user.TeamName),
               IsActive: ConvertBooleanToStringPr(user.IsActive)
           ));
        }
        return userModels;
    }

    private static string ConvertBooleanToStringPr(bool isActive)
    {
        return isActive ? "Sim" : "Não";
    }

    private static string GetDescriptionTeam(int team)
    {
        return Team.GetByDescription(team);
    }
}