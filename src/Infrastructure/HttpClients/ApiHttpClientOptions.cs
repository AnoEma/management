using System.ComponentModel.DataAnnotations;

namespace Infrastructure.HttpClients;

public record ApiHttpClientOptions
{
    public string UserAgent { get; init; } = string.Empty;
    public TimeSpan FirstRetryDelay { get; init; } = TimeSpan.FromMilliseconds(500);
    public int RetryCount { get; init; } = 0;
    public string ApiKey { get; init; } = string.Empty;
}
