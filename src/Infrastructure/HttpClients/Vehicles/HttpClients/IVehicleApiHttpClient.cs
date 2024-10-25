using CSharpFunctionalExtensions;

namespace Infrastructure.HttpClients.Vehicles.HttpClients;

public interface IVehicleApiHttpClient
{
    Task<Result<VehicleResponse>> GetVehicleByPlateAsync(VehicleResquest request, CancellationToken cancellationToken);
}