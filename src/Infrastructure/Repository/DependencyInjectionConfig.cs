using Infrastructure.Repository.Leads;
using Infrastructure.Repository.SolicitationLeads.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository;

public static class DependencyInjectionConfig
{
    public static void AddRepositoty(this IServiceCollection services)
    {
        //Query
        services.AddScoped<ISolicitationLeadQueryRepository, SolicitationLeadQueryRepository>();

        //Command
        services.AddScoped<ILeadCommandRepository, LeadCommandRepository>();
    }
}
