using Application.UseCases.Addresses.Models;
using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Addresses.HttpClients;

namespace Application.UseCases.Addresses;

public class GetAddressQueryHandler(IAddressApiHttpClient addressApiHttpClient) : IGetAddressQueryHandler
{
    public async Task<Result<GetAddressResponse>> HandlerAsync(GetAddressQuery query, CancellationToken cancellationToken = default)
    {
        string zipCode = query.ZipCode.Replace("-", "");
        Result<AddressResponse> result = await addressApiHttpClient.GetAddressAsync(zipCode, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<GetAddressResponse>($"Error: {result.Error}");
        }
        GetAddressResponse response = GetAddressResponse.CreateAddressResponse(result.Value);

        return Result.Success(response);
    }
}
