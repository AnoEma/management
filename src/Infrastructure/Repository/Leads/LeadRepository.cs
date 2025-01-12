using CSharpFunctionalExtensions;
using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.Leads;

public class LeadRepository(InfrastructureDbContext context) : ILeadRepository
{
    public async Task<Result<int>> SaveLeadAsync(SolicitationLead command, CancellationToken cancellationToken = default)
    {
        await context.SolicitationLeads.AddAsync(command, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(command.Id);
    }
}
