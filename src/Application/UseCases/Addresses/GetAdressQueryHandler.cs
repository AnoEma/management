using Application.UseCases.Addresses.Models;
using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Addresses.HttpClients;

namespace Application.UseCases.Addresses;

public class GetAdressQueryHandler(IAddressApiHttpClient addressApiHttpClient) : IGetAdressQueryHandler
{
    public async Task<Result<GetAdressResponse>> HandlerAsync(GetAdressQuery query, CancellationToken cancellationToken = default)
    {
        string zipCode = query.ZipCode.Replace("-", "");
        Result<AddressResponse> result = await addressApiHttpClient.GetAddressAsync(zipCode, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<GetAdressResponse>($"Error: {result.Error}");
        }
        GetAdressResponse response = GetAdressResponse.CreateAddressResponse(result.Value);

        return Result.Success(response);
    }
}
