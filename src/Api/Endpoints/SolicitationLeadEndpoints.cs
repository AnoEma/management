using Api.Extentions;
using Api.Models.Request;
using Application.UseCases.SolicitationLead;
using Microsoft.AspNetCore.Mvc;
using Monad = CSharpFunctionalExtensions;

namespace Api.Endpoints;

public static class SolicitationLeadEndpoints
{
    public static void AddSolicitationRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder customerApi = app
            .MapGroup("/solicitation")
            .WithSummary("Handel customer api")
            .WithTags("solicitation");

        customerApi
            .MapPost("/", CreateLead)
            .WithName(nameof(CreateLead))
            .Produces<string>(StatusCodes.Status200OK);

    }

    private static async Task<IResult> CreateLead(
        [FromServices] ICreateSolicitationLeadCommandHandler commandHandler,
        [FromBody] QuotationRequest quotation,
        CancellationToken cancellationToken)
    {
        CreateSolicitationLeadCommand solicitationLead = quotation.ToCommand();
        Monad.Result result = await commandHandler.HandleAsync(solicitationLead, cancellationToken);

        return result.IsSuccess ? Results.Created() : result.ToActionResult();
    }
}
