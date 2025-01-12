using CSharpFunctionalExtensions;
using Infrastructure.Repository.Users;
using Infrastructure.Repository.Users.Commands;

namespace Application.UseCases.Users.Commands;

internal class CreateUserCommandHandler(IUserRepository repository) : ICreateUserCommandHandler
{
    public async Task<Result> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            User createUser = CreateUserCommand.CreateUserCommandToUser(command);

            Result<int> result = await repository.SaveAsync(createUser, cancellationToken);

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