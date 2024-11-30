using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.Leads;

public interface ILeadCommandRepository
{
    Task<Result<int>> SaveLeadAsync(SolicitationLead command, CancellationToken cancellationToken = default);
}