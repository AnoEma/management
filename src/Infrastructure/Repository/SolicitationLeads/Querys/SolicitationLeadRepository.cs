using CSharpFunctionalExtensions;
using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Leads.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.SolicitationLeads.Querys;

public class SolicitationLeadRepository(InfrastructureDbContext context) : ISolicitationLeadRepository
{
    public async Task<Result> GetSolicitationLeadByDocumentAsync(string document, CancellationToken cancellationToken)
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
            .SolicitationLeads
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return result;
    }
}
