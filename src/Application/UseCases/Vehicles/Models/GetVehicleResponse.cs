using Infrastructure.HttpClients.Vehicles.HttpClients;

namespace Application.UseCases.Vehicles.Models;

public record GetVehicleResponse(
string FipeCode,
string Model,
string Brand,
string ManufactureYear,
string ModelYear,
string Plate,
string Chassi
)
{
    public static GetVehicleResponse CreateVehicleResponse(VehicleResponse value)
    {
        return new(
            FipeCode: GetFipeCode(value),
            Model: GetModel(value),
            Brand: value.marca,
            ManufactureYear: value.ano_fabricacao,
            ModelYear: value.ano_modelo,
            Plate: value.placa,
            Chassi: value.chassi
        );

        static string GetModel(VehicleResponse value)
        {
            return value.Fipe.FirstOrDefault().descricao;
        }

        static string GetFipeCode(VehicleResponse value)
        {
            return value.Fipe.FirstOrDefault().codigo;
        }
    }
}
