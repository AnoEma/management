using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Customers;
using Infrastructure.Repository.Users;
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
        services.AddSingleton<InfrastructureDbContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
