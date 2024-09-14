
using Api.Extentions;
using CSharpFunctionalExtensions;

namespace Api.Endpoints;

public static class CustomerEndpoints
{
    public static void AddCustomerRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder customerApi = app
            .MapGroup("/customer")
            .WithSummary("Handel customer api")
            .WithTags("customer");

        customerApi
            .MapGet("/", GetCustomer)
            .WithName(nameof(GetCustomer));
            //.Produces<string>(StatusCodes.Status200OK);

    }

    private static async Task<Microsoft.AspNetCore.Http.IResult> GetCustomer(HttpContext context)
    {
        Result<string> result = "Hello world...";
        return result.ToActionResult();
    }
}
