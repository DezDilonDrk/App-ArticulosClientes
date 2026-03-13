using System.Net;
using System.Text.Json;

namespace Articulos_Backend.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var statusCode = HttpStatusCode.InternalServerError;

        if (exception is KeyNotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
        }
        else if (exception is UnauthorizedAccessException)
        {
            statusCode = HttpStatusCode.Unauthorized;
        }

        response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new { error = exception.Message });
        return response.WriteAsync(result);
    }
}
