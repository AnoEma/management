namespace Infrastructure.Repository.Customers;

public class CustomerRepository : ICustomerRepository
{
    public Task AddAsync(CustomerCommand entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(CustomerCommand entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerCommand>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerCommand> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CustomerCommand entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
