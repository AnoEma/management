using CSharpFunctionalExtensions;
using System.Text;

namespace Infrastructure.HttpClients.Addresses.HttpClients;

public class AddressApiHttpClient(HttpClient httpClient) : IAddressApiHttpClient
{
    public async Task<Result<AddressResponse>> GetAddressAsync(string zipCode, CancellationToken cancellationToken = default)
    {
        try
        {
            StringContent content = new(BuildCommand(zipCode), Encoding.UTF8);
            using HttpResponseMessage httpResponse = await httpClient.PostAsync("/soap/Teleport", content, cancellationToken);

            httpResponse.EnsureSuccessStatusCode();

            var response = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
            AddressResponse result = AddressResponse.CreateResponse(response);

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<AddressResponse>($"Error occurred : {ex.Message}");
        }
    }
    private static string BuildCommand(string zipCode)
    {
        string password = "G580r$fW$$$@@fhOt%5029#fZZZs%8jQp.nX*tf86.T%gAgp";

        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
                      <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                          <soap:Body>
                             <ConsultaCEP xmlns=""http://teleport.com.br/"">
                                <senha>{password}</senha>
                                <CEP>{zipCode}</CEP>
                            </ConsultaCEP>
                          </soap:Body>
                     </soap:Envelope>"
        ;
    }
}
