using CSharpFunctionalExtensions;
using Infrastructure.Repository.Users;
using Infrastructure.Repository.Users.Commands;

namespace Application.UseCases.Users.Commands;

internal class UserCommandHandler(IUserRepository repository) : IUserCommandHandler
{
    public async Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default)
    {
        try
        {
            return await repository.DeleteAsync(userId, cancellationToken);
        }
        catch (Exception ex)
        {
            return Result.Failure($"An error occurred while deleting the user. {ex}");
        }
    }

    public async Task<Result> HandleAsync(UserCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            UserManagement createUser = UserCommand.CreateUserCommandToUser(command);

            Result<int> result = await repository.SaveAsync(createUser, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<int>(result.Error);
            }

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<int>(error: ex.Message);
        }
    }

    public async Task<Result> UpdateAsync(UserCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            UserManagement createUser = UserCommand.CreateUserCommandToUser(command);

            var result = await repository.UpdateAsync(createUser, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<int>(result.Error);
            }

            return Result.Success(result);
        }
        catch (Exception)
        {
            throw;
        }
    }
}