using Application.Model;
using CSharpFunctionalExtensions;

namespace Application.UseCases.SolicitationLeads.Querys;

public interface ISolicitationLeadQueryHandler
{
    Task<Result<IEnumerable<Solicitation>>> Handler(CancellationToken cancellationToken = default);
}