using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Modules.School.WebAPI.Extensions.ExceptionHandling;
using Modules.School.WebAPI.Extensions;
using Modules.School.WebAPI.Contracts;
namespace Modules.School.WebAPI.Middleware;

/// <summary>
/// Global exception handler. Catches unhandled system/infrastructure exceptions,
/// logs them, and returns a consistent ApiResponse JSON.
/// </summary>
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
    private readonly IWebHostEnvironment _env;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        if (context.Response.HasStarted)
        {
            _logger.LogError(exception, "Response already started; cannot write error response. Rethrowing.");
            throw exception;
        }

        var (statusCode, message) = ExceptionMapping.Map(exception);

        if (_env.IsDevelopment() && statusCode >= 500 && !string.IsNullOrWhiteSpace(exception.Message))
            message = exception.Message;

        _logger.LogError(exception, "Unhandled exception. {Message} | StatusCode: {StatusCode}", exception.Message, statusCode);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = ApiResponse.Fail(message, errors: new List<string> { message });
        var json = JsonSerializer.Serialize(response, JsonOptions);
        await context.Response.WriteAsync(json);
    }
}
