using Api.Extentions;
using Application.UseCases.Vehicles;
using Application.UseCases.Vehicles.Models;
using Microsoft.AspNetCore.Mvc;
using Monad = CSharpFunctionalExtensions;


namespace Api.Endpoints;

public static class VehicleEndpoints
{
    public static void AddVehicleRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder vehicleApi = app
            .MapGroup("/vehicle")
            .WithSummary("Handel vehicle api")
            .WithTags("vehicle");

        vehicleApi
            .MapGet("/{plate}", GetVehicle)
            .WithName(nameof(GetVehicle))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }

    private static async Task<IResult> GetVehicle(
        [FromServices] IGetVehicleQueryHandler queryHandler,
        [FromRoute] string plate,
        CancellationToken cancellationToken)
    {
        GetVehicleQuery query = new(plate);

        Monad.Result<GetVehicleResponse> result = await queryHandler.HandlerAsync(query, cancellationToken);
        return result.ToActionResult();
    }
}
