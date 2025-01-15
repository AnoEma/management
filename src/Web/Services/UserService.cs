using Application.UseCases.Users.Commands;
using Application.UseCases.Users.Querys;
using CSharpFunctionalExtensions;
using Web.Model;
using Web.Services.Interfaces;

namespace Web.Services;

internal class UserService(
    IUserCommandHandler commandHandler,
    IGetAllUserQueryHandler queryHandler
) : IUserService
{
    public async Task<Result> AddUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        UserCommand createUserCommand = UserModel.CreateUserCommand(user);

        var response = await commandHandler.HandleAsync(createUserCommand, cancellationToken);

        if (response.IsFailure)
        {
            return Result.Failure(response.Error);
        }
        return Result.Success(response);
    }

    public async Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default)
    {
        Result respoense = await commandHandler.DeleteAsync(userId, cancellationToken);
        if (respoense.IsFailure)
        {
            return Result.Failure(respoense.Error);
        }
        return Result.Success(respoense);
    }

    public async Task<Result<UserModel>> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        Result<UserCommand> result = await queryHandler.HandleAsync(userId, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<UserModel>(result.Error);
        }
        UserModel response = UserModel.CreateUserModel(result.Value);

        return Result.Success(response);
    }

    public async Task<Result<IReadOnlyList<GetAllUserModel>>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        Result<IReadOnlyList<GetAllUserQuery>> result = await queryHandler.HandleAsync(cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<IReadOnlyList<GetAllUserModel>>(result.Error);
        }
        IReadOnlyList<GetAllUserModel> response = GetAllUserModel.CreateUserModelList(result.Value);

        return Result.Success(response);
    }

    public async Task<Result> UpdateUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        UserCommand createUserCommand = UserModel.CreateUserCommand(user);

        var response = await commandHandler.UpdateAsync(createUserCommand, cancellationToken);

        if (response.IsFailure)
        {
            return Result.Failure(response.Error);
        }
        return Result.Success(response);
    }
}
