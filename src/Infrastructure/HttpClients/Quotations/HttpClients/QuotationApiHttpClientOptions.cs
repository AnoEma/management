namespace Infrastructure.HttpClients.Quotations.HttpClients;

public sealed record QuotationApiHttpClientOptions : ApiHttpClientOptions
{
    public string SoapAction { get; init; } = string.Empty;
    public string AccessKey { get; init; } = string.Empty;
    public string AccessKeyCorr { get; init; } = string.Empty;
    public string CodeCorr { get; init; } = string.Empty;
}
