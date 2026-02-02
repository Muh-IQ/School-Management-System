namespace Modules.School.Application.Common.Results;

public class Result<T> : Result
{
    public T? Value { get; private set; }

    protected Result(bool isSuccess, T? value, ErrorType errorType, string errorMessage)
        : base(isSuccess, errorType, errorMessage)
    {
        Value = value;
    }

    
      public static Result<T> Success(T value)
        => new Result<T>(true, value, ErrorType.None, string.Empty);

    public static new Result<T> Failure(ErrorType errorType, string errorMessage)
        => new Result<T>(false, default, errorType, errorMessage);

    public new Result<T> WithError(ErrorType errorType, string errorMessage)
    {
        base.WithError(errorType, errorMessage);
        return this;
    }
}
