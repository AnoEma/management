﻿using Infrastructure.DataConfiguration;
using Infrastructure.HttpClients.Addresses;
using Infrastructure.HttpClients.Persons;
using Infrastructure.HttpClients.Quotations;
using Infrastructure.HttpClients.Vehicles;
using Infrastructure.Repository;
using Infrastructure.Repository.Users.Commands;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionConfig
{
    public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InfrastructureDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ManagementDataBase"));
        });
        services
            .AddDefaultIdentity<ManagementUser>()
            .AddEntityFrameworkStores<InfrastructureDbContext>();

        services.AddRepositoty();

        services.AddQuotationApiHttpClients(configuration);
        services.AddPersonApiHttpClients(configuration);
        services.AddVehicleApiHttpClients(configuration);
        services.AddAddressApiHttpClients(configuration);
    }
}
