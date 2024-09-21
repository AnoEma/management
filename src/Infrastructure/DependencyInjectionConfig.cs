using Infrastructure.DataConfiguration;
using Infrastructure.Repository.Customers;
using Infrastructure.Repository.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionConfig
{
    public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InfrastructureDbContext>(options =>
        {
            
        });
        services.AddSingleton<InfrastructureDbContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
