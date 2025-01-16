using Api.Extentions;
using Api.Models.Request;
using Application.UseCases.SolicitationLeads;
using Application.UseCases.SolicitationLeads.Querys;
using Microsoft.AspNetCore.Mvc;
using Monad = CSharpFunctionalExtensions;

namespace Api.Endpoints;

public static class SolicitationLeadEndpoints
{
    public static void AddSolicitationRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder solicitationApi = app
            .MapGroup("/solicitation")
            .WithSummary("Handel customer api")
            .WithTags("solicitation");

        solicitationApi
            .MapPost("/", CreateLead)
            .WithName(nameof(CreateLead))
            .Produces<string>(StatusCodes.Status201Created);

        solicitationApi
            .MapGet("/", GetAllLead)
            .WithName(nameof(GetAllLead))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
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

    private static async Task<IResult> GetAllLead(
        [FromServices] ISolicitationLeadQueryHandler queryHandler,
        CancellationToken cancellationToken)
    {
        Monad.Result result = await queryHandler.HandlerAsync(cancellationToken);
        return result.ToActionResult();
    }
}
