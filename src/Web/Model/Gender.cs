namespace Web.Model;

public record Gender(GenderType Value, string Text)
{
    public static IReadOnlyList<Gender> GetGenders { get; } =
    [
        new(GenderType.None, string.Empty),
        new(GenderType.Masculino, "Masculino"),
        new(GenderType.Feminino, "Feminino"),
        new(GenderType.NaoBinario, "Não Binário")
    ];

    public static Gender GetByValue(string value) =>
       GetGenders.FirstOrDefault(gender => gender.Text == value);
}

public enum GenderType : byte
{
    None,
    Masculino,
    Feminino,
    NaoBinario
}

public record MaritalStatus(MaritalStatusType Value, string Variant, string Text)
{
    public static IReadOnlyList<MaritalStatus> GetMaritalStatuses { get; } =
    [
        new(MaritalStatusType.None, "None", string.Empty),
        new(MaritalStatusType.Single, "Single", "Solteiro(a)"),
        new(MaritalStatusType.Married, "Married", "Casado(a)"),
        new(MaritalStatusType.Divorced, "Divorced", "Separado(a)"),
        new(MaritalStatusType.Widower, "Widower", "Viúvo(a)")
    ];

    public static MaritalStatus GetByValue(string value) =>
        GetMaritalStatuses.FirstOrDefault(gender => gender.Variant == value);
}

public enum MaritalStatusType : byte
{
    None,
    Single,
    Married,
    Divorced,
    Widower
}