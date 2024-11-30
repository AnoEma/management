namespace Infrastructure.HttpClients.Addresses.HttpClients;

public sealed record AddressApiHttpClientOptions: ApiHttpClientOptions
{
    public string SoapAction { get; init; } = string.Empty;
    public string AccessKey { get; init; } = string.Empty;
}
