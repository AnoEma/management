using CSharpFunctionalExtensions;
using Infrastructure.Extensions;
using Microsoft.Extensions.Options;
using System.Text;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public class QuotationApiHttpClient(HttpClient httpClient, IOptions<QuotationApiHttpClientOptions> options) : IQuotationApiHttpClient
{
    public async Task<Result<QuotationResponse>> CreatQuotationAsync(QuotationRequest command, CancellationToken cancellationToken = default)
    {
        try
        {
            string commandRequest = command.SerializeRequestToXml();

            StringContent content = new(
                BuildCommand(
                    commandRequest, 
                    options.Value.AccessKey, 
                    options.Value.AccessKeyCorr, 
                    options.Value.CodeCorr), 
                Encoding.UTF8);

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

    private static string BuildCommand(string command, string accessKey, string accessKeyCorr, string codeCorr)
    {
        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                            <soap:Body>
                                <GravarCalculo xmlns=""http://teleport.com.br/"">
                                    <senha>{accessKey}</senha>
                                    <CodCorr>{codeCorr}</CodCorr>
                                    <SenhaCorr>{accessKeyCorr}</SenhaCorr>
                                    <XML>{command}</XML>
                                </GravarCalculo>
                            </soap:Body>
                        </soap:Envelope>"
        ;
    }
}
