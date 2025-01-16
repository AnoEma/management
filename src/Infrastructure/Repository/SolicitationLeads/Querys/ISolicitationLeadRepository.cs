using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.SolicitationLeads.Querys;

public interface ISolicitationLeadRepository
{
    Task<Result<SolicitationLead>> GetSolicitationLeadByDocumentAsync(string document, CancellationToken cancellationToken = default);
    Task<Result<SolicitationLead>> GetSolicitationLeadByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<SolicitationLead>> GetSolicitationLeadByOpportuniteLeadIdAsync(int opportuniteLeadId, CancellationToken cancellationToken = default);
    Task<Result<List<SolicitationLead>>> GetSolicitationLeadAsync(CancellationToken cancellationToken = default);
}