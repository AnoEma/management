using CSharpFunctionalExtensions;

namespace Infrastructure.HttpClients.Persons.HttpClients;

public interface IPersonApiHttpClient
{
    Task<Result<PersonResponse>> GetPerson(PersonRequest request, CancellationToken cancellationToken = default);
}