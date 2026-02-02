namespace Modules.School.Application.Common.Results;
public class Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;

    public List<Error> Errors { get;private set; }

    protected Result(bool isSuccess, ErrorType errorType, string errorMessage)
    {
        IsSuccess = isSuccess;
        Errors = new List<Error> { Error.Create(errorType, errorMessage) };
    }
    public static  Result Success()
        => new Result(true, ErrorType.None, string.Empty);

    public static Result Failure(ErrorType errorType, string errorMessage)
        => new Result(false, errorType, errorMessage);

    public Result WithError(ErrorType errorType, string errorMessage)
    {
        Errors.Add(Error.Create(errorType, errorMessage)); 
        return this;
    }
}
 