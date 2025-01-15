using CSharpFunctionalExtensions;
using Web.Model;

namespace Web.Services.Interfaces;

public interface IUserService
{
    Task<Result> AddUserAsync(UserModel user, CancellationToken cancellationToken = default);
    Task<Result> UpdateUserAsync(UserModel user, CancellationToken cancellationToken = default);
    //Task<Result> DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<UserModel>> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyList<GetAllUserModel>>> GetUsersAsync(CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default);
}
