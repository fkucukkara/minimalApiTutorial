using MinimalApi.Middleware;

namespace MinimalApi.Extensions;
public static class MiddlewareExtensions
{
    public static void UseExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
