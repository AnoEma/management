using CSharpFunctionalExtensions;
using Infrastructure.Repository.Customers;

namespace Application.UseCases.Customers.CreateCustomers;

public class CreateCustomersCommandHandler(ICustomerRepository _repository) : ICreateCustomersCommandHandler
{
    public async Task<IResult> HandlerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        CustomerCommand command = CreateCommand(customer);

        var result = _repository.AddAsync(command);
        return Result.Success(result);
    }

    private static CustomerCommand CreateCommand(Customer customerDto)
    {
        return new CustomerCommand(
            customerDto.Id
            );
    }
}
