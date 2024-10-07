using CSharpFunctionalExtensions;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public class QuotationApiHttpClient(HttpClient httpClient) : IQuotationApiHttpClient
{
    public async Task<Result> CreatQuotationAsync(QuotationCommand command, CancellationToken cancellationToken = default)
    {
		try
		{
			StringContent content = null;
			using HttpResponseMessage httpResponse = await httpClient.PostAsync("", content, cancellationToken);

			httpResponse.EnsureSuccessStatusCode();

			return Result.Success(httpResponse);
		}
		catch (Exception ex)
		{
			return Result.Failure<HttpResponseMessage>($"Error occurred : {ex.Message}");
		}
    }
}
