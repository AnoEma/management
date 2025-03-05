namespace Web.Model;

public record DecisionMakerModel(string Value, string Text)
{
    public static IReadOnlyList<DecisionMakerModel> GetDecisionMakerModels { get; } = 
    [
        new("false", ""),
        new("true", "Sim"),
        new("false", "Não"),
    ];

    public static DecisionMakerModel GetByValue(string value) =>
   GetDecisionMakerModels.FirstOrDefault(gender => gender.Text == value);
}
