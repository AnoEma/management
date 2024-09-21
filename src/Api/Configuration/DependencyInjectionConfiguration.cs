using Application;
using Infrastructure;

namespace Api.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHealthChecks();
        builder.Services.AddInfrastructureService(builder.Configuration);
        builder.Services.AddAplicationService();
    }
}
