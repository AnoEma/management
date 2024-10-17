using System.ComponentModel.DataAnnotations;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public sealed record QuotationApiHttpClientOptions : ApiHttpClientOptions
{
    public string SoapAction { get; init; } = string.Empty;
}
