using Application.UseCases.Addresses;
using Application.UseCases.Persons;
using Application.UseCases.SolicitationLeads;
using Application.UseCases.SolicitationLeads.Querys;
using Application.UseCases.Users.Commands;
using Application.UseCases.Users.Querys;
using Application.UseCases.Vehicles;
using Infrastructure.Repository.Users;
using Infrastructure.Repository.Users.Commands;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        services.AddScoped<IGetAdressQueryHandler, GetAdressQueryHandler>();
        services.AddScoped<IGetAllUserQueryHandler, GetAllUserQueryHandler>();

        //Command Handlers
        services.AddScoped<ICreateSolicitationLeadCommandHandler, CreateSolicitationLeadCommandHandler>();
        services.AddScoped<IUserCommandHandler, UserCommandHandler>();
    }
}
