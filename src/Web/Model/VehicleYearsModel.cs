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
