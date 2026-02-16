namespace Modules.School.WebAPI.Extensions.ExceptionHandling;

/// <summary>
/// Maps system/infrastructure exceptions to HTTP status codes and safe user-facing messages.
/// Handles only technical errors (500, 408, etc.) - business logic uses Result pattern.
/// </summary>
public static class ExceptionMapping
{
    public static (int StatusCode, string Message) Map(Exception exception)
    {
        return exception switch
        {
            ArgumentNullException ex => (400, string.IsNullOrWhiteSpace(ex.ParamName)
                ? "The request could not be processed due to invalid input."
                : $"The request could not be processed. Invalid value for '{ex.ParamName}'."),
            ArgumentException ex => (400, string.IsNullOrWhiteSpace(ex.Message)
                ? "The request could not be processed due to invalid input."
                : ex.Message),
            KeyNotFoundException => (404, "The requested resource was not found."),
            UnauthorizedAccessException => (401, "You are not authorized to perform this operation."),
            InvalidOperationException ex when ex.Message.Contains("conflict", StringComparison.OrdinalIgnoreCase) => (409, "The operation could not be completed due to a conflict."),
            InvalidOperationException ex => (400, string.IsNullOrWhiteSpace(ex.Message) ? "The request could not be processed." : ex.Message),
            OperationCanceledException => (408, "The operation was cancelled or timed out."),
            TimeoutException => (408, "The operation timed out. Please try again later."),
            _ => (500, "An internal server error occurred. Please try again later.")
        };
    }
}
