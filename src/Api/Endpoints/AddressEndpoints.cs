
using Api.Extentions;
using Application.UseCases.Addresses;
using Application.UseCases.Addresses.Models;
using Microsoft.AspNetCore.Mvc;
using Monad = CSharpFunctionalExtensions;


namespace Api.Endpoints;

public static class AddressEndpoints
{
    public static void AddAddressRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder addressApi = app
            .MapGroup("/address")
            .WithSummary("Handel address api")
            .WithTags("address");

        addressApi
            .MapGet("/{zipCode}", GetAddress)
            .WithName(nameof(GetAddress))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> GetAddress(
        [FromServices] IGetAddressQueryHandler queryHandler,
        [FromRoute] string zipCode,
        CancellationToken cancellationToken)
    {
        GetAddressQuery query = new(zipCode);

        Monad.Result<GetAddressResponse> result = await queryHandler.HandlerAsync(query, cancellationToken);

        return result.ToActionResult();
    }
}
