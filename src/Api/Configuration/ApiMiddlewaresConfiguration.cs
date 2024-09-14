namespace Api.Configuration;

public static class ApiMiddlewaresConfiguration
{
    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.MapHealthChecks("/health");

        app.UseExceptionHandler();
        app.UseHttpsRedirection();
    }
}
