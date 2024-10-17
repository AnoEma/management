using CSharpFunctionalExtensions;
using System.Net.Http.Json;

namespace Infrastructure.HttpClients.Persons.HttpClients;

public class PersonApiHttpClient(HttpClient httpClient) : IPersonApiHttpClient
{
    public async Task<Result<PersonResponse>> GetPerson(PersonRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = $"?cpf_cnpj={request.CpfCnpj}&estrutura_vendas={request.EstruturaVendas}&source={request.Source}&tipo_pessoa={request.TipoPessoa}";

            using HttpResponseMessage httpResponse = await httpClient.GetAsync($"/gateway/route/gateway/person/v1/search{query}", cancellationToken);

            httpResponse.EnsureSuccessStatusCode();

            PersonResponse? response = await httpResponse.Content.ReadFromJsonAsync<PersonResponse>(cancellationToken);

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            return Result.Failure<PersonResponse>(ex.Message);
        }
    }
}
