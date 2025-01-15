using CSharpFunctionalExtensions;

namespace Application.UseCases.Users.Commands;

public interface IUserCommandHandler
{
    Task<Result> HandleAsync(UserCommand command, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(UserCommand command, CancellationToken cancellationToken = default);
}