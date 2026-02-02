namespace Modules.School.Application.Common.Results;


public class Error
{

    public ErrorType ErrorType { get; private set; }


    public string Message { get; private set; }

    private Error()
    {
        
    }
    private Error(ErrorType errorType, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Error message cannot be null or empty.", nameof(message));

        ErrorType = errorType;
        Message = message;
    }
    

    public static Error Create(ErrorType errorType, string message) => new Error(errorType, message);
}
