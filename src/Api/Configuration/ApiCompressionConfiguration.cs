using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Api.Configuration;

public static class ApiCompressionConfiguration
{
    public static void ConfigureResponseCompression(this WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });

        builder.Services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.SmallestSize;
        });
    }
}
