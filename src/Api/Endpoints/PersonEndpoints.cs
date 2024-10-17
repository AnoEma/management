
using Api.Extentions;
using Application.UseCases.Persons;
using Application.UseCases.Persons.Models;
using Microsoft.AspNetCore.Mvc;
using Monad = CSharpFunctionalExtensions;


namespace Api.Endpoints;

public static class PersonEndpoints
{
    public static void AddPersonRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder personApi = app
            .MapGroup("/person")
            .WithSummary("Handel person api")
            .WithTags("person");

        personApi
            .MapGet("/{document}/{personType}", GetPerson)
            .WithName(nameof(GetPerson))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }

    private static async Task<IResult> GetPerson(
       [FromServices] IGetPersonQueryHandler queryHandler,
       [FromRoute] string document,
       [FromRoute] string personType,
       CancellationToken cancellationToken)
    {
        GetPersonQuery query = new(document, personType);

        Monad.Result<GetPersonResponse> result = await queryHandler.HandlerAsync(query, cancellationToken);

        return result.ToActionResult();
    }
}
