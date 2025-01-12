using CSharpFunctionalExtensions;
using Web.Model;

namespace Web.Services.Interfaces;

public interface IUserService
{
    Task<Result> AddUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
