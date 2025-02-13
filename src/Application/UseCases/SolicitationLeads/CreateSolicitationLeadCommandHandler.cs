using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads;

namespace Application.UseCases.SolicitationLeads;

public class CreateSolicitationLeadCommandHandler(
    ILeadRepository commandRepository
) : ICreateSolicitationLeadCommandHandler
{
    public async Task<Result> HandleAsync(CreateSolicitationLeadCommand command, CancellationToken cancellationToken = default)
    {
        Result<int> result = await commandRepository.SaveLeadAsync(CreateSolicitationLeadCommandHandlerHelpers.CreateCommand(command), cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure("Erro");
        }

        return Result.Success(result);
    }
}
