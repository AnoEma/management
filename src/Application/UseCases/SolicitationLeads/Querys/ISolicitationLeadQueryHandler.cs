using Application.Model;
using CSharpFunctionalExtensions;

namespace Application.UseCases.SolicitationLeads.Querys;

public interface ISolicitationLeadQueryHandler
{
    Task<Result<IReadOnlyList<Solicitation>>> HandlerAsync(CancellationToken cancellationToken = default);
    Task<Result<Solicitation>> HandlerByLeadIdAsync(int leadId, CancellationToken cancellationToken = default);
}