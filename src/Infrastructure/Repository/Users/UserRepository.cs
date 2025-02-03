using CSharpFunctionalExtensions;
using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Users.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Users;

internal class UserRepository(InfrastructureDbContext context) : IUserRepository
{
    public async Task<Result<List<UserManagement>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        Result<List<UserManagement>> result = await context
            .UserManagements
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<Result<UserManagement>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Result<UserManagement> result = await context
            .UserManagements
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return result;
    }

    public async Task<Result<UserManagement>> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        Result<UserManagement> result = await context
            .UserManagements
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == userName, cancellationToken);
        return result;
    }

    public async Task<Result<int>> SaveAsync(UserManagement command, CancellationToken cancellationToken = default)
    {
        await context.UserManagements.AddAsync(command, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(command.Id);
    }
    public async Task<Result> DeleteAsync(int userId, CancellationToken cancellationToken = default)
    {
        await context.UserManagements
                   .Where(x => x.Id == userId)
                   .ExecuteUpdateAsync(update =>
                        update
                        .SetProperty(
                            x => x.IsActive,
                            x => false)
                        .SetProperty(
                            x => x.DateDismissal,
                            x => DateTime.Now)
                        , cancellationToken);

        return Result.Success();
    }

    public async Task<Result> UpdateAsync(UserManagement command, CancellationToken cancellationToken = default)
    {
        #region Update User
        await context.UserManagements
          .Where(x => x.Id == command.Id)
          .ExecuteUpdateAsync(update =>
            update
            .SetProperty(
                x => x.FirstName,
                x => command.FirstName)
            .SetProperty(
                x => x.LastName,
                x => command.LastName)
            .SetProperty(
                x => x.PhoneNumber,
                x => command.PhoneNumber)
            .SetProperty(
                x => x.Gender,
                x => command.Gender)
            .SetProperty(
                x => x.Email,
                x => command.Email)
            .SetProperty(
                x => x.AccessLevel,
                x => command.AccessLevel)
            .SetProperty(
                x => x.TeamName,
                x => command.TeamName)
            .SetProperty(
                x => x.UpdatedAt,
                x => DateTime.Now)
            , cancellationToken); 
        #endregion

        return Result.Success();
    }
}
