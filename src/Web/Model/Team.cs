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
};
