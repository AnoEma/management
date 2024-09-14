namespace Api.Extentions;

public static class GetCorrelationIdHttpContextExtension
{
    public static string GetCorrelation(this HttpContext httpContext)
    {
        return httpContext?.Request?.Headers["X-Correlation-ID"].FirstOrDefault() 
            ?? Guid.NewGuid().ToString();
    }
}
