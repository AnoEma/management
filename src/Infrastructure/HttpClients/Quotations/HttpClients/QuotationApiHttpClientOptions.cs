using System.ComponentModel.DataAnnotations;

namespace Infrastructure.HttpClients.Quotations.HttpClients;

public sealed record QuotationApiHttpClientOptions : ApiHttpClientOptions
{
    [Required, Url]
    public string BaseUrl { get; init; } = string.Empty;
    public string SoapAction { get; init; } = string.Empty;

}
