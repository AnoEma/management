namespace Web.Model;

public record Team(int Value, string Text)
{
    public static IReadOnlyList<Team> GetTeams { get; } =
    [
        new(0, ""),
        new(1, "Detroide"),
        new(2, "Feminino"),
        new(3, "Não Binário")
    ];
};
