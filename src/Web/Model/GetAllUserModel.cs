using Application.UseCases.Users.Querys;

namespace Web.Model;

public record GetAllUserModel
(
    int Id,
    string Name,
    string User,
    int Team,
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
               Team: user.TeamName,
               IsActive: ConvertBooleanToStringPr(user.IsActive)
           ));
        }
        return userModels;
    }

    private static string ConvertBooleanToStringPr(bool isActive)
    {
        return isActive ? "Sim" : "Não";
    }
}