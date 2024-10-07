using CSharpFunctionalExtensions;

namespace Application.UseCases.Customers.CreateCustomers;

public interface ICreateCustomersCommandHandler
{
    Task<IResult> HandlerAsync(Customer customer, CancellationToken cancellationToken = default);
}