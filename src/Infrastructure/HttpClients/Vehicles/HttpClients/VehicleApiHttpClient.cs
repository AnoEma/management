using CSharpFunctionalExtensions;
using System.Net.Http.Json;

namespace Infrastructure.HttpClients.Vehicles.HttpClients;

public class VehicleApiHttpClient(HttpClient httpClient) : IVehicleApiHttpClient
{
    public async Task<Result<VehicleResponse>> GetVehicleByPlateAsync(VehicleResquest request, CancellationToken cancellationToken)
    {
        try
        {
            var query = $"?campo={request.Campo}&estrutura_vendas={request.EstruturaVendas}&source={request.Source}&valor={request.Valor}";

            using HttpResponseMessage httpResponse = await httpClient.GetAsync($"/gateway/route/gateway/vehicle/v1/search{query}", cancellationToken);

            httpResponse.EnsureSuccessStatusCode();

            VehicleResponse? response = await httpResponse.Content.ReadFromJsonAsync<VehicleResponse>(cancellationToken);

            return Result.Success(response);
        }
        catch (Exception)
        {
            throw;
		}
    }
}
