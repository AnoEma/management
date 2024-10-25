using Application.UseCases.Vehicles.Models;
using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Vehicles.HttpClients;

namespace Application.UseCases.Vehicles;

public class GetVehicleQueryHandler(IVehicleApiHttpClient vehicleApiHttp) : IGetVehicleQueryHandler
{
    private const string FIELD = "PLACA";
    private const string SOURCE = "TELEPORT";
    private const string ESTRUTURA_VENDAS = "1";

    public async Task<Result<GetVehicleResponse>> HandlerAsync(GetVehicleQuery query, CancellationToken cancellationToken = default)
    {
        VehicleResquest request = CreateRequest(query);

        Result<VehicleResponse> result = await vehicleApiHttp.GetVehicleByPlateAsync(request, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<GetVehicleResponse>("Erro");
        }

        GetVehicleResponse response = GetVehicleResponse.CreateVehicleResponse(result.Value);

        return Result.Success(response);
    }

    private static VehicleResquest CreateRequest(GetVehicleQuery query)
    {
        return new(
            Campo: FIELD,
            Source: SOURCE,
            EstruturaVendas: ESTRUTURA_VENDAS,
            Valor: query.Plate
        );
    }
}
