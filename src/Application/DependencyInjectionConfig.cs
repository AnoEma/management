using Application.UseCases.Persons;
using Application.UseCases.SolicitationLeads;
using Application.UseCases.SolicitationLeads.Querys;
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
        services.AddScoped<ISolicitationLeadQueryHandler, SolicitationLeadQueryHandler>();

        //Command Handlers
        services.AddScoped<ICreateSolicitationLeadCommandHandler, CreateSolicitationLeadCommandHandler>();
    }
}
