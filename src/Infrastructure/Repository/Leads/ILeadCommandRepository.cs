using CSharpFunctionalExtensions;
using Infrastructure.Repository.Leads.Commands;

namespace Infrastructure.Repository.Leads;

public interface ILeadCommandRepository
{
    Task SaveLeadAsync(SolicitationLead command, CancellationToken cancellationToken = default);
}