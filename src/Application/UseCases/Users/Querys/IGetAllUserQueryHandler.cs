using Application.UseCases.Users.Commands;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Users.Querys;

public interface IGetAllUserQueryHandler
{
    Task<Result<IReadOnlyList<GetAllUserQuery>>> HandleAsync(CancellationToken cancellationToken = default);
    Task<Result<UserCommand>> HandleAsync(int userId, CancellationToken cancellationToken = default);
}