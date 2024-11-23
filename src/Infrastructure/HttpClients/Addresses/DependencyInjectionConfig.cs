using Infrastructure.HttpClients.Addresses.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace Infrastructure.HttpClients.Addresses;

public static class DependencyInjectionConfig
{
    public static void AddAddressApiHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        AddOptions(services, configuration);


        services
           .AddHttpClient<IAddressApiHttpClient, AddressApiHttpClient>((serviceProvider, client) =>
           {
               AddressApiHttpClientOptions options = serviceProvider
                   .GetRequiredService<IOptions<AddressApiHttpClientOptions>>().Value;

               if (!string.IsNullOrEmpty(options.UserAgent))
               {
                   client.DefaultRequestHeaders.Add("X-API-KEY", options.ApiKey);
                   client.DefaultRequestHeaders.Add("SOAPAction", options.SoapAction);
               }

               client.BaseAddress = new Uri(options.BaseUrl);
           })
           .AddPolicyHandler(GetRetryPolicy(configuration))
           .SetHandlerLifetime(TimeSpan.FromMinutes(5));
    }

    private static void AddOptions(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<AddressApiHttpClientOptions>()
            .Bind(configuration.GetSection(nameof(AddressApiHttpClientOptions)));
    }

    private static AsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfiguration configuration)
    {
        AddressApiHttpClientOptions retryOptions = configuration
            .GetSection(nameof(AddressApiHttpClientOptions))
            .Get<AddressApiHttpClientOptions>();

        IEnumerable<TimeSpan> delay = Backoff
            .DecorrelatedJitterBackoffV2(medianFirstRetryDelay: retryOptions?.FirstRetryDelay ?? TimeSpan.Zero, retryCount: retryOptions?.RetryCount ?? 0);

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(delay);
    }
}
