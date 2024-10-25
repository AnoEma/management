using Infrastructure.HttpClients.Vehicles.HttpClients;

namespace Application.UseCases.Vehicles.Models;

public record GetVehicleResponse(
string Code,
string Model,
string Brand,
string ManufactureYear,
string ModelYear,
string Plate,
string Fuel,
string Chassi
)
{
    public static GetVehicleResponse CreateVehicleResponse(VehicleResponse value)
    {
        return new(
            Code: "",
            Model: value.modelo,
            Brand: value.marca,
            ManufactureYear: value.ano_fabricacao,
            ModelYear: value.ano_modelo,
            Plate: value.placa,
            Fuel: GetFuelTypeCode(value.combustivel),
            Chassi: value.chassi
        );
    }

    private static string GetFuelTypeCode(string typeFuel) => typeFuel.ToLowerInvariant() switch
    {
        "gasolina" => "1",
        "alcool" => "2",
        "diesel" => "3",
        "eletrico" => "4",
        "alcool / gasolina" => "5",
        "gasolina / adaptado a gas" => "6",
        "alcool / adaptado a gas" => "7",
        "outros" => "12",
        _ => string.Empty
    };
}
