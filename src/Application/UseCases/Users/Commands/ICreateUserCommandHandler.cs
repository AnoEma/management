using CSharpFunctionalExtensions;

namespace Application.UseCases.Users.Commands;

public interface ICreateUserCommandHandler
{
    Task<Result> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default);
}