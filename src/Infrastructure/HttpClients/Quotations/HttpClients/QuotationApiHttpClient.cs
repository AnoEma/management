using CSharpFunctionalExtensions;
using Infrastructure.Extensions;
using System.Text;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public class QuotationApiHttpClient(HttpClient httpClient) : IQuotationApiHttpClient
{
    public async Task<Result<QuotationResponse>> CreatQuotationAsync(QuotationRequest command, CancellationToken cancellationToken = default)
    {
        try
        {
            string commandRequest = command.Serialize();

            StringContent content = new(BuildCommand(commandRequest), Encoding.UTF8);
            using HttpResponseMessage httpResponse = await httpClient.PostAsync("/soap/Teleport", content, cancellationToken);

            httpResponse.EnsureSuccessStatusCode();

            var response = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

            QuotationResponse result = QuotationResponse.CreateResponse(response);

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<QuotationResponse>($"Error occurred : {ex.Message}");
        }
    }

    private static string BuildCommand(string command)
    {
        string password = "G580r$fW$$$@@fhOt%5029#fZZZs%8jQp.nX*tf86.T%gAgp";
        string codeCorr = "16975";
        string passwordCorr = "P169@pot";

        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                            <soap:Body>
                                <GravarCalculo xmlns=""http://teleport.com.br/"">
                                    <senha>{password}</senha>
                                    <CodCorr>{codeCorr}</CodCorr>
                                    <SenhaCorr>{passwordCorr}</SenhaCorr>
                                    <XML>{command}</XML>
                                </GravarCalculo>
                            </soap:Body>
                        </soap:Envelope>"
        ;
    }
}
