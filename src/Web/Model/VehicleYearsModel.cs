namespace Web.Model;

public record VehicleYearsModel(int value, string text)
{
    public static IReadOnlyList<VehicleYearsModel> GetVehicleYears { get; } = GetYearsModels();

    private static IReadOnlyList<VehicleYearsModel> GetYearsModels()
    {
        int startYear = 2009;
        int currentYear = DateTime.Now.Year;

        return [new VehicleYearsModel(0, ""),
            .. Enumerable.Range(startYear, currentYear - startYear)
                         .Select(year => new VehicleYearsModel(year, $"{year} - {year + 1}"))];
    }
}

public record VehicleUsoModel(TypeVehicleUso Value, string Variant, string Text)
{
    public static IReadOnlyList<VehicleUsoModel> GetVehicleUsoModels { get; } =
    [
        new(TypeVehicleUso.None, "None", string.Empty),
        new(TypeVehicleUso.JustLeisure, "JustLeisure", "Somente lazer"),
        new(TypeVehicleUso.CommutingFromWork, "CommutingFromWork", "Ida e volta ao trabalho"),
        new(TypeVehicleUso.Commercially, "Commercially", "Comercialmente"),
        new(TypeVehicleUso.AppTaxiDriver, "AppTaxiDriver", "Motorista de app/taxi")
    ];

    public static VehicleUsoModel GetByValue(string value) =>
        GetVehicleUsoModels.FirstOrDefault(gender => gender.Variant == value);
}

public enum TypeVehicleUso : byte
{
    None = 0,
    JustLeisure,
    CommutingFromWork,
    Commercially,
    AppTaxiDriver
}
