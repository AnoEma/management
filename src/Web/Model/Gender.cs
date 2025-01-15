namespace Web.Model;

public record Gender(int Value, string Text)
{
    public static IReadOnlyList<Gender> GetGenders { get; } =
    [
        new(3, ""),
        new(1, "Masculino"),
        new(2, "Feminino"),
        new(4, "Não Binário")
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