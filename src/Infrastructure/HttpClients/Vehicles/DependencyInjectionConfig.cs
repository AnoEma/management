using Infrastructure.HttpClients.Vehicles.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace Infrastructure.HttpClients.Vehicles;

public static class DependencyInjectionConfig
{
    public static void AddVehicleApiHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        AddOptions(services, configuration);


        services
           .AddHttpClient<IVehicleApiHttpClient, VehicleApiHttpClient>((serviceProvider, client) =>
           {
               VehicleApiHttpClientOptions options = serviceProvider
                   .GetRequiredService<IOptions<VehicleApiHttpClientOptions>>().Value;

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
           .AddOptions<VehicleApiHttpClientOptions>()
           .Bind(configuration.GetSection(nameof(VehicleApiHttpClientOptions)));
    }

    private static AsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfiguration configuration)
    {
        VehicleApiHttpClientOptions retryOptions = configuration
            .GetSection(nameof(VehicleApiHttpClientOptions))
            .Get<VehicleApiHttpClientOptions>();

        IEnumerable<TimeSpan> delay = Backoff
            .DecorrelatedJitterBackoffV2(medianFirstRetryDelay: retryOptions?.FirstRetryDelay ?? TimeSpan.Zero, retryCount: retryOptions?.RetryCount ?? 0);

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(delay);
    }
}
