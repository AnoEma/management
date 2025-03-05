namespace Web.Model;

public record TypeResidentialModel(TypeResidential Value, string Text)
{
    public static IReadOnlyList<TypeResidentialModel> GetTypeResidentialModels { get; } =
    [
       new(TypeResidential.None, ""),
       new(TypeResidential.Casa, "Casa"),
       new(TypeResidential.CondominioFechado, "Condominio Fechado"),
       new(TypeResidential.Apartamento, "Apartamento"),
       new(TypeResidential.Outros, "Outros"),
    ];

    public static TypeResidentialModel GetByValue(string value) =>
   GetTypeResidentialModels.FirstOrDefault(gender => gender.Value.ToString() == value);
}
public enum TypeResidential: byte
{
    None = 0,
    Casa,
    CondominioFechado,
    Apartamento,
    Outros
}
