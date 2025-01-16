using Application.Model;
using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads.Commands;
using Infrastructure.Repository.SolicitationLeads.Querys;


namespace Application.UseCases.SolicitationLeads.Querys;

public class SolicitationLeadQueryHandler(ISolicitationLeadRepository queryRepository) : ISolicitationLeadQueryHandler
{
    public async Task<Result<IReadOnlyList<Solicitation>>> HandlerAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            Result<List<SolicitationLead>> result = await queryRepository.GetSolicitationLeadAsync(cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<IReadOnlyList<Solicitation>>("Erro...");
            }

            IReadOnlyList<Solicitation> solicitations = Solicitation.CreateSolicitationsModel(result.Value);

            return Result.Success(solicitations);
        }
        catch (Exception ex)
        {
            return Result.Failure<IReadOnlyList<Solicitation>>($"Erro...{ex.Message}");
        }
    }

    public async Task<Result<Solicitation>> HandlerByLeadIdAsync(int leadId, CancellationToken cancellationToken = default)
    {
        try
        {
            Result<SolicitationLead> result = await queryRepository.GetSolicitationLeadByIdAsync(leadId, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<Solicitation>("Erro...");
            }

            Solicitation solicitation = Solicitation.ConvertSolicitationLeadToSolicitation(result.Value);

            return Result.Success(solicitation);
        }
        catch (Exception ex)
        {
            return Result.Failure<Solicitation>($"Erro...{ex.Message}");
        }
    }
}
