
using System.Net;

public class HttpResponseMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<HttpResponseMiddleware> _logger;

    public HttpResponseMiddleware(RequestDelegate next, ILogger<HttpResponseMiddleware> logger)
    {
        _next = next;
        _logger = logger;
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

        switch (context.Response.StatusCode)
        {
            case (int)HttpStatusCode.BadRequest: // 400
                await WriteResponse(context, "Bad request.");
                break;
            case (int)HttpStatusCode.Unauthorized: // 401
                await WriteResponse(context, "Unauthorized access.");
                break;
            case (int)HttpStatusCode.Forbidden: // 403
                await WriteResponse(context, "Access to this resource is forbidden.");
                break;
            case (int)HttpStatusCode.NotFound: // 404
                await WriteResponse(context, "Resource not found.");
                break;
            case (int)HttpStatusCode.InternalServerError: // 500
                await WriteResponse(context, "An unexpected error occurred.");
                break;
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError($"An error ocurred: ${exception}");

        if (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync("{\"message\":\"An unexpected error occurred.\"}");
        }

        return Task.CompletedTask;
    }
    private static async Task WriteResponse(HttpContext context, string message)
    {
        if (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync($"{{\"message\":\"{message}\"}}");
        }
    }
}