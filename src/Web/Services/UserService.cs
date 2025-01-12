using Application.UseCases.Users.Commands;
using CSharpFunctionalExtensions;
using Web.Model;
using Web.Services.Interfaces;

namespace Web.Services;

internal class UserService(
    ICreateUserCommandHandler commandHandler
) : IUserService
{
    public async Task<Result> AddUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        CreateUserCommand createUserCommand = UserModel.CreateUserCommand(user);

        var response = await commandHandler.HandleAsync(createUserCommand, cancellationToken);

        if (response.IsFailure)
        {
            return Result.Failure(response.Error);
        }
        return Result.Success(response);
    }
}
