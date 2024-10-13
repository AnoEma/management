using System.ComponentModel.DataAnnotations;

namespace Infrastructure.HttpClients.Persons.HttpClients;

public sealed record PersonApiHttpClientOptions : ApiHttpClientOptions
{
    [Required, Url]
    public string BaseUrl { get; init; } = string.Empty;
}
