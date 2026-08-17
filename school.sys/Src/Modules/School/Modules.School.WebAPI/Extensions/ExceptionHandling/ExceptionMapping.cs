namespace Modules.School.WebAPI.Extensions.ExceptionHandling;

/// <summary>
/// Maps system/infrastructure exceptions to HTTP status codes and safe user-facing messages.
/// Handles only technical errors (500, 408, etc.) - business logic uses Result pattern.
/// </summary>
public static class ExceptionMapping
{
    public static (int StatusCode, string Message) Map(Exception exception)
    {
        return (
            StatusCodes.Status500InternalServerError,
            "An unexpected error occurred. Please try again later"
        );
    }
}