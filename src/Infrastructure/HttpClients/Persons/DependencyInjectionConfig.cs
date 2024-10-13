using Infrastructure.HttpClients.Persons.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace Infrastructure.HttpClients.Persons;

public static class DependencyInjectionConfig
{
    public static void AddPersonApiHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        AddOptions(services, configuration);


        services
           .AddHttpClient<IPersonApiHttpClient, PersonApiHttpClient>((serviceProvider, client) =>
           {
               PersonApiHttpClientOptions options = serviceProvider
                   .GetRequiredService<IOptions<PersonApiHttpClientOptions>>().Value;

               if (!string.IsNullOrEmpty(options.UserAgent))
               {
                   client.DefaultRequestHeaders.Add("X-API-KEY", options.ApiKey);
                   client.DefaultRequestHeaders.Add("Accept", "*/*");
                   client.DefaultRequestHeaders.Add("Accept-Encoding", "*");
               }

               client.BaseAddress = new Uri(options.BaseUrl);
           })
           .AddPolicyHandler(GetRetryPolicy(configuration))
           .SetHandlerLifetime(TimeSpan.FromMinutes(5));
    }
    private static void AddOptions(IServiceCollection services, IConfiguration configuration)
    {
        services
           .AddOptions<PersonApiHttpClientOptions>()
           .Bind(configuration.GetSection(nameof(PersonApiHttpClientOptions)));
    }

    private static AsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfiguration configuration)
    {
        PersonApiHttpClientOptions? retryOptions = configuration
            .GetSection(nameof(PersonApiHttpClientOptions))
            .Get<PersonApiHttpClientOptions>();

        IEnumerable<TimeSpan> delay = Backoff
            .DecorrelatedJitterBackoffV2(medianFirstRetryDelay: retryOptions?.FirstRetryDelay ?? TimeSpan.Zero, retryCount: retryOptions?.RetryCount ?? 0);

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(delay);
    }
}
