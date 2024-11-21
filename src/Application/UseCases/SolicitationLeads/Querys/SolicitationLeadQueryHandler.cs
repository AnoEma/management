using Application.Model;
using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads.Commands;
using Infrastructure.Repository.SolicitationLeads.Querys;


namespace Application.UseCases.SolicitationLeads.Querys;

public class SolicitationLeadQueryHandler(ISolicitationLeadQueryRepository queryRepository) : ISolicitationLeadQueryHandler
{
    public async Task<Result<IEnumerable<Solicitation>>> Handler(CancellationToken cancellationToken = default)
    {
        Result<List<SolicitationLead>> result = await queryRepository.GetSolicitationLeadAsync(cancellationToken);

        if(result.IsFailure)
        {
            return Result.Failure<IEnumerable<Solicitation>>("Erro...");
        }

        IEnumerable<Solicitation> solicitation = Solicitation.CreateSolicitationModel(result.Value);

        return Result.Success(solicitation);
    }
}
