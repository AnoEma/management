using CSharpFunctionalExtensions;
using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Leads.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.SolicitationLeads.Querys;

public class SolicitationLeadRepository(InfrastructureDbContext context) : ISolicitationLeadRepository
{
    public async Task<Result<SolicitationLead>> GetSolicitationLeadByDocumentAsync(string document, CancellationToken cancellationToken)
    {
        Result<SolicitationLead> result = await context
            .SolicitationLeads
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OpportuniteLead.Insured.Cpf == document, cancellationToken);

        return result;
    }

    public async Task<Result<List<SolicitationLead>>> GetSolicitationLeadAsync(CancellationToken cancellationToken = default)
    {
        Result<List<SolicitationLead>> result = await context
            .Set<SolicitationLead>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<Result<SolicitationLead>> GetSolicitationLeadByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Result<SolicitationLead> result = await context
            .SolicitationLeads
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return result;
    }

    public async Task<Result<SolicitationLead>> GetSolicitationLeadByOpportuniteLeadIdAsync(int opportuniteLeadId, CancellationToken cancellationToken = default)
    {
        Result<SolicitationLead> result = await context
            .SolicitationLeads
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OpportuniteLead.Id == opportuniteLeadId, cancellationToken);

        return result;
    }
}
