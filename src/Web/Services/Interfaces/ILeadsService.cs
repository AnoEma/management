using CSharpFunctionalExtensions;
using Web.Model;

namespace Web.Services.Interfaces;

public interface ILeadsService
{
    Task<Result<IReadOnlyList<LeadsModel>>> GetLeads(CancellationToken cancellationToken);
}