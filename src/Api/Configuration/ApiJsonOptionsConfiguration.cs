using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Configuration;

public static class ApiJsonOptionsConfiguration
{
    public static void ConfigureJsonOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
            options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });
    }
}
