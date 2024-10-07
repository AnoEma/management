using CSharpFunctionalExtensions;

namespace Application.UseCases.SolicitationLead;

public interface ICreateSolicitationLeadCommandHandler
{
    Task<Result> HandleAsync(CreateSolicitationLeadCommand command, CancellationToken cancellationToken = default);
}