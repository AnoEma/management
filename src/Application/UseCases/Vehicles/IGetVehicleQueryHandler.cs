using Application.UseCases.Vehicles.Models;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Vehicles;

public interface IGetVehicleQueryHandler
{
    Task<Result<GetVehicleResponse>> HandlerAsync(GetVehicleQuery query, CancellationToken cancellationToken = default);

}