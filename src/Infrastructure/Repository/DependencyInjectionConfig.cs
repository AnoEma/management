using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Leads;
using Infrastructure.Repository.SolicitationLeads.Querys;
using Infrastructure.Repository.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository;

public static class DependencyInjectionConfig
{
    public static void AddRepositoty(this IServiceCollection services)
    {
        services.AddScoped<ISolicitationLeadRepository, SolicitationLeadRepository>();
        services.AddScoped<ILeadRepository, LeadRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
