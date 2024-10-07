namespace Infrastructure.HttpClients.Quotations.HttpClients;

public sealed record QuotationApiHttpClientOptions : ApiHttpClientOptions
{
    public string ApiKey { get; init; } = string.Empty;
    public string SoapAction { get; init; } = string.Empty;

}
