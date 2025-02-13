using Application.UseCases.Addresses.Models;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Addresses;

public interface IGetAddressQueryHandler
{
    Task<Result<GetAddressResponse>> HandlerAsync(GetAddressQuery query, CancellationToken cancellationToken = default);
}