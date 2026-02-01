namespace Modules.School.Application.Common.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public IReadOnlyList<Error> Errors { get; }

    protected Result(bool isSuccess, ErrorType errorType, string errorMessage)
    {
        IsSuccess = isSuccess;
        Errors = new List<Error> { Error.Create(errorType, errorMessage) };
    }
    public static Result Success()
        => new Result(true, ErrorType.None, string.Empty);

    public static Result Failure( ErrorType errorType, string errorMessage)
        => new Result(false, errorType, errorMessage);

    public Result WithError(ErrorType errorType, string errorMessage)
    {
        var errorsList = new List<Error>(Errors);
        errorsList.Add(Error.Create(errorType, errorMessage));
        return new Result(false, errorType, errorMessage);
    } 
}
 