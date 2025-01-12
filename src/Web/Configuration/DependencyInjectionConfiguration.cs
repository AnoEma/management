using Application;
using Infrastructure;
using Web.Services;
using Web.Services.Interfaces;

namespace Web.Configuration;


public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructureService(builder.Configuration);
        builder.Services.AddAplicationService();

        builder.Services.AddScoped<IUserService, UserService>();
    }
}
