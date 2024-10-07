using System.ComponentModel.DataAnnotations;

namespace Infrastructure.HttpClients;

public record ApiHttpClientOptions
{
    [Required, Url] public string BaseUrl { get; init; } = string.Empty;
    public string UserAgent { get; init; } = string.Empty;
    public TimeSpan FirstRetryDelay { get; init; } = TimeSpan.FromMilliseconds(500);
    public int RetryCount { get; init; } = 0;
}
