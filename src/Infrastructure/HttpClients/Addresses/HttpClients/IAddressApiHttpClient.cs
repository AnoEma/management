using CSharpFunctionalExtensions;

namespace Infrastructure.HttpClients.Addresses.HttpClients;

public interface IAddressApiHttpClient
{
    Task<Result> GetAddressAsync(string zipCode, CancellationToken cancellationToken = default);
}