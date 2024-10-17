using Application.UseCases.Persons;
using Application.UseCases.SolicitationLead;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionConfig
{
    public static void AddAplicationService(this IServiceCollection services)
    {
        //Query Handlers
        services.AddScoped<IGetPersonQueryHandler, GetPersonQueryHandler>();

        //Command Handlers
        services.AddScoped<ICreateSolicitationLeadCommandHandler, CreateSolicitationLeadCommandHandler>();
    }
}
