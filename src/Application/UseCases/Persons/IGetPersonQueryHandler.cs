using Application.UseCases.Persons.Models;
using CSharpFunctionalExtensions;

namespace Application.UseCases.Persons;

public interface IGetPersonQueryHandler
{
   Task<Result<GetPersonResponse>> HandlerAsync(GetPersonQuery query, CancellationToken cancellationToken = default);
}