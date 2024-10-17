using Application.UseCases.Persons.Models;
using CSharpFunctionalExtensions;
using Infrastructure.HttpClients.Persons.HttpClients;

namespace Application.UseCases.Persons;

public class GetPersonQueryHandler(IPersonApiHttpClient personApiHttpClient) : IGetPersonQueryHandler
{
    public async Task<Result<GetPersonResponse>> HandlerAsync(GetPersonQuery query, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest(query);

        Result<PersonResponse> result = await personApiHttpClient.GetPerson(request, cancellationToken);

        if (result.IsFailure)
        {
            return Result.Failure<GetPersonResponse>("");
        }
        GetPersonResponse response = GetPersonResponse.CreatePersonResponse(result.Value);

        return Result.Success(response);
    }

    private static PersonRequest CreateRequest(GetPersonQuery query)
    {
        return new(
            CpfCnpj: query.Cpf,
            EstruturaVendas: "1",
            Source: "TELEPORT",
            TipoPessoa: GetTipoPessoa(query)
        );
    }

    private static string GetTipoPessoa(GetPersonQuery query)
    {
        return query.PersonType == "1" ? Constants.Person.PERSON_FISICA : Constants.Person.PERSON_JURIDICA;
    }
}
