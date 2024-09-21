using Infrastructure.DataConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Customers;

public class CustomerRepository : BaseRepository<CustomerCommand>, ICustomerRepository
{
    public CustomerRepository(InfrastructureDbContext context, DbSet<CustomerCommand> dbSet) : base(context, dbSet){}
}
