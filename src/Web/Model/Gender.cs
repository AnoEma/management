namespace Web.Model;

public record Gender(GenderType Value, string Text)
{
    public static IReadOnlyList<Gender> GetGenders { get; } =
    [
        new(GenderType.None, ""),
        new(GenderType.Masculino, "Masculino"),
        new(GenderType.Feminino, "Feminino"),
        new(GenderType.NaoBinario, "Não Binário")
    ];

    public static Gender GetByValue(string value) =>
       GetGenders.FirstOrDefault(gender => gender.Text == value);
}

public enum GenderType : int
{
    Masculino = 1,
    Feminino,
    None,
    NaoBinario
}