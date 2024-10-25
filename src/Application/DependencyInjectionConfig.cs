using Application.UseCases.Persons;
using Application.UseCases.SolicitationLead;
using Application.UseCases.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionConfig
{
    public static void AddAplicationService(this IServiceCollection services)
    {
        //Query Handlers
        services.AddScoped<IGetPersonQueryHandler, GetPersonQueryHandler>();
        services.AddScoped<IGetVehicleQueryHandler, GetVehicleQueryHandler>();

        //Command Handlers
        services.AddScoped<ICreateSolicitationLeadCommandHandler, CreateSolicitationLeadCommandHandler>();
    }
}
