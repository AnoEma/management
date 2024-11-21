using CSharpFunctionalExtensions;

namespace Application.UseCases.SolicitationLeads;

public interface ICreateSolicitationLeadCommandHandler
{
    Task<Result> HandleAsync(CreateSolicitationLeadCommand command, CancellationToken cancellationToken = default);
}