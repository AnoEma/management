using Api.Endpoints;

namespace Api.Configuration;

public static class ApiEndpointsConfiguration
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.AddSolicitationRoutes();
        app.AddPersonRoutes();
        app.AddVehicleRoutes();
        app.AddAddressRoutes();
    }
}
