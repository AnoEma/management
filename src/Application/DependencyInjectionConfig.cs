﻿using Application.UseCases.Addresses;
using Application.UseCases.Persons;
using Application.UseCases.SolicitationLeads;
using Application.UseCases.SolicitationLeads.Querys;
using Application.UseCases.Users.Commands;
using Application.UseCases.Users.Querys;
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
        services.AddScoped<IGetAddressQueryHandler, GetAddressQueryHandler>();
        services.AddScoped<IGetAllUserQueryHandler, GetAllUserQueryHandler>();

        //Command Handlers
        services.AddScoped<ICreateSolicitationLeadCommandHandler, CreateSolicitationLeadCommandHandler>();
        services.AddScoped<IUserCommandHandler, UserCommandHandler>();
    }
}
