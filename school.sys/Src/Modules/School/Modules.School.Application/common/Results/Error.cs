namespace Modules.School.Application.Common.Results;

/// <summary>
/// Represents an error that occurred during an operation.
/// </summary>
public class Error
{
    /// <summary>
    /// Gets the type of error that occurred.
    /// </summary>
    public ErrorType ErrorType { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Initializes a new instance of the Error class.
    /// </summary>
    /// <param name="errorType">The type of error that occurred.</param>
    /// <param name="message">The error message.</param>
    private Error(ErrorType errorType, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Error message cannot be null or empty.", nameof(message));

        ErrorType = errorType;
        Message = message;
    }
    
    /// <summary>
    /// Creates an error with the specified type and message.
    /// </summary>
    /// <param name="errorType">The type of error that occurred.</param>
    /// <param name="message">The error message.</param>
    /// <returns>A new Error instance.</returns>
    public static Error Create(ErrorType errorType, string message) => new Error(errorType, message);
}
