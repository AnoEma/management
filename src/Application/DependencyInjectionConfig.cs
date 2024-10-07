using Application.UseCases.SolicitationLead;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionConfig
{
    public static void AddAplicationService(this IServiceCollection services)
    {
        //Query Handlers

        //Command Handlers
        services.AddScoped<ICreateSolicitationLeadCommandHandler, CreateSolicitationLeadCommandHandler>();
    }
}
