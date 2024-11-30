using CSharpFunctionalExtensions;
using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.Leads;

public class LeadCommandRepository(InfrastructureDbContext context) : ILeadCommandRepository
{
    public async Task<Result<int>> SaveLeadAsync(SolicitationLead command, CancellationToken cancellationToken = default)
    {
        await context.SolicitationLeads.AddAsync(command, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(command.Id);
    }
}
