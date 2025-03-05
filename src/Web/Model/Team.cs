using System.ComponentModel;

namespace Web.Model;

public record Team(int Value, string Text)
{
    public static IReadOnlyList<Team> GetTeams { get; } =
    [
        new(0, ""),
        new(1, "Detroide"),
        new(2, "Las Vegas"),
        new(3, "São Paulo"),
        new(4, "Tulsa")
    ];
    public static Team GetByValue(string value) =>
    GetTeams.FirstOrDefault(option => option.Value.ToString() == value);

    public static string GetByDescription(int value)
    {
        return GetTeams.FirstOrDefault(option => option.Value == value).Text;
    }
};

public enum TypeTeam
{
    [Description("")]
    None,
    [Description("São Paulo")]
    Matrix,
    [Description("Las Vegas")]
    Filial,
    [Description("Tulsa")]
    Tech
}
