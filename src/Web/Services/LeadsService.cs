using Application.Model;
using Application.UseCases.SolicitationLeads;
using Application.UseCases.SolicitationLeads.Querys;
using CSharpFunctionalExtensions;
using Web.Model;
using Web.Services.Interfaces;

namespace Web.Services;

internal class LeadsService(
    ISolicitationLeadQueryHandler queryHandler,
    ICreateSolicitationLeadCommandHandler commandHandler
) : ILeadsService
{
    public async Task<Result> CreateLead(CreateSolicitationLeadModel model, CancellationToken cancellationToken)
    {
        CreateSolicitationLeadCommand command = CreateSolicitationLeadModel.CreateCommand(model);

        Result result = await commandHandler.HandleAsync(command, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<Result>($"Erro... {result.Error}");
        }

        return Result.Success(result);
    }

    public async Task<Result<IReadOnlyList<LeadsModel>>> GetLeads(CancellationToken cancellationToken)
    {
        Result<IReadOnlyList<Solicitation>> result = await queryHandler.HandlerAsync(cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<IReadOnlyList<LeadsModel>>(result.Error);
        }

        IReadOnlyList<LeadsModel> response = LeadsModel.CreateLeadsModel(result.Value);

        return Result.Success(response);
    }
}
