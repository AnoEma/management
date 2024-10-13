using Infrastructure.DataConfiguration;
using Infrastructure.HttpClients.Persons;
using Infrastructure.HttpClients.Quotations;
using Infrastructure.Repository;
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
            options.UseSqlServer(configuration.GetConnectionString("management-database"));
        });

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddQuotationApiHttpClients(configuration);
        services.AddPersonApiHttpClients(configuration);
    }
}
