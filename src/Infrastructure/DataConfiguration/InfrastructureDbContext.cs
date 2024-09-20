using Infrastructure.Repository.Customers;
using Infrastructure.Repository.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataConfiguration;

public class InfrastructureDbContext : DbContext
{
    public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options)
    {
    }

    public DbSet<CustomerCommand> CustomerCommands { get; set; }
    public DbSet<UserCommand> UserCommands { get; set; }
}