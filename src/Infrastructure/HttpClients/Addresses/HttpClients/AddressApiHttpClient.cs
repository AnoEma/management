using CSharpFunctionalExtensions;
using System.Text;
using System.Xml.Serialization;

namespace Infrastructure.HttpClients.Addresses.HttpClients;

public class AddressApiHttpClient(HttpClient httpClient) : IAddressApiHttpClient
{
    public async Task<Result> GetAddressAsync(string zipCode, CancellationToken cancellationToken = default)
    {
        try
        {
            StringContent content = new(BuildCommand(zipCode), Encoding.UTF8);
            using HttpResponseMessage httpResponse = await httpClient.PostAsync("/soap/Teleport", content, cancellationToken);

            httpResponse.EnsureSuccessStatusCode();

            var response = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
            AddressResponse result = ReadXlm(response);

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<HttpResponseMessage>($"Error occurred : {ex.Message}");
        }
    }

    private static AddressResponse ReadXlm(string response)
    {
        XmlSerializer soapSerializer = new XmlSerializer(typeof(SoapEnvelope));
        using StringReader reader = new StringReader(response);
        SoapEnvelope envelope = (SoapEnvelope)soapSerializer.Deserialize(reader);
        string encodedReturn = envelope.Body.ConsultaCEPResponse.Return;

        string decodedReturn = System.Net.WebUtility.HtmlDecode(encodedReturn);

        XmlSerializer addressSerializer = new(typeof(AddressResponse));

        using StringReader addressReader = new(decodedReturn);
        return (AddressResponse)addressSerializer.Deserialize(addressReader);
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
