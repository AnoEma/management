using CSharpFunctionalExtensions;
using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Users.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Users;

internal class UserRepository(InfrastructureDbContext context) : IUserRepository
{
    public async Task<Result<List<User>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        Result<List<User>> result = await context
            .Users
            .AsNoTracking()
            .Where(x => x.IsActive)
            .ToListAsync(cancellationToken);

        return result;
    }

    public async Task<Result<User>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Result<User> result = await context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return result;
    }

    public async Task<Result<int>> SaveAsync(User command, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(command, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success(command.Id);
    }
    public async Task DeleteAsync(int userId, CancellationToken cancellationToken = default)
    {
        await context.Users
                   .Where(x => x.Id == userId)
                   .ExecuteUpdateAsync(update =>
                        update
                        .SetProperty(
                            x => x.IsActive,
                            x => false)
                        .SetProperty(
                            x => x.DeleteIn,
                            x => DateTime.Now)
                        ,cancellationToken);
    }
}
