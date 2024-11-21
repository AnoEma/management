using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.Leads;

public class LeadCommandRepository(InfrastructureDbContext context) : ILeadCommandRepository
{
    public async Task SaveLeadAsync(SolicitationLead command, CancellationToken cancellationToken = default)
    {
        var result = await context.SolicitationLeads.AddAsync(command, cancellationToken);
        var test = await context.SaveChangesAsync(cancellationToken);
    }
}
