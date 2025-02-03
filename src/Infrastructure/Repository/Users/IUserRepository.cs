using CSharpFunctionalExtensions;
using Infrastructure.Repository.Users.Commands;

namespace Infrastructure.Repository.Users;

public interface IUserRepository
{
    Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default);
    Task<Result<List<UserManagement>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<UserManagement>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<UserManagement>> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task<Result<int>> SaveAsync(UserManagement command, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(UserManagement command, CancellationToken cancellationToken = default);
}