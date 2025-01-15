using Application.UseCases.Users.Commands;
using CSharpFunctionalExtensions;
using Infrastructure.Repository.Users;
using Infrastructure.Repository.Users.Commands;

namespace Application.UseCases.Users.Querys;

internal class GetAllUserQueryHandler(IUserRepository repository) : IGetAllUserQueryHandler
{
    public async Task<Result<IReadOnlyList<GetAllUserQuery>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            Result<List<User>> result = await repository.GetAllAsync(cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<IReadOnlyList<GetAllUserQuery>>(result.Error);
            }
            IReadOnlyList<GetAllUserQuery> response = GetAllUserQuery.CreateUserQueryList(result.Value);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            return Result.Failure<IReadOnlyList<GetAllUserQuery>>(ex.Message);
        }
    }
    public async Task<Result<UserCommand>> HandleAsync(int userId, CancellationToken cancellationToken = default)
    {
        try
        {
            Result<User> result = await repository.GetByIdAsync(userId, cancellationToken);
            
            if(result.IsFailure)
            {
                return Result.Failure<UserCommand>(result.Error);
            }

            UserCommand response = UserCommand.ConvertUserToUserCommand(result.Value);

          return Result.Success(response);
        }
        catch (Exception ex)
        {
            return Result.Failure<UserCommand>(ex.Message);
        }
    }
}