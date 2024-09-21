using Infrastructure.DataConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Users;

public class UserRepository : BaseRepository<UserCommand>, IUserRepository
{
    public UserRepository(InfrastructureDbContext context, DbSet<UserCommand> dbSet) : base(context, dbSet){}
}
