using Infrastructure.HttpClients.Quotations.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace Infrastructure.HttpClients.Quotations;

public static class DependencyInjectionConfig
{
    public static void AddQuotationApiHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        AddOptions(services, configuration);


        services
           .AddHttpClient<IQuotationApiHttpClient, QuotationApiHttpClient>((serviceProvider, client) =>
           {
               QuotationApiHttpClientOptions options = serviceProvider
                   .GetRequiredService<IOptions<QuotationApiHttpClientOptions>>().Value;

               if (!string.IsNullOrEmpty(options.UserAgent))
               {
                   client.DefaultRequestHeaders.Add("SOAPAction", options.SoapAction);
                   client.DefaultRequestHeaders.Add("X-API-KEY", options.ApiKey);
               }

               client.BaseAddress = new Uri(options.BaseUrl);
           })
           .AddPolicyHandler(GetRetryPolicy(configuration))
           .SetHandlerLifetime(TimeSpan.FromMinutes(5));
    }
    private static void AddOptions(IServiceCollection services, IConfiguration configuration)
    {
        services
           .AddOptions<QuotationApiHttpClientOptions>()
           .Bind(configuration.GetSection(nameof(QuotationApiHttpClientOptions)));
    }

    private static AsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfiguration configuration)
    {
        QuotationApiHttpClientOptions retryOptions = configuration
            .GetSection(nameof(QuotationApiHttpClientOptions))
            .Get<QuotationApiHttpClientOptions>();

        IEnumerable<TimeSpan> delay = Backoff
            .DecorrelatedJitterBackoffV2(medianFirstRetryDelay: retryOptions?.FirstRetryDelay ?? TimeSpan.Zero, retryCount: retryOptions?.RetryCount ?? 0);

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(delay);
    }
}
