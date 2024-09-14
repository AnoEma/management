using Api.Endpoints;

namespace Api.Configuration;

public static class ApiEndpointsConfiguration
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.AddCustomerRoutes();
    }
}
