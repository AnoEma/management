using Application.UseCases.Addresses.Models;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Addresses;

public interface IGetAdressQueryHandler
{
    Task<Result<GetAdressResponse>> HandlerAsync(GetAdressQuery query, CancellationToken cancellationToken = default);
}