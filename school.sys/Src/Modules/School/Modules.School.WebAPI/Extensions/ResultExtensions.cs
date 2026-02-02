using Modules.School.Application.Common.Results;
using Modules.School.WebAPI.Contracts;

namespace Modules.School.WebAPI.Extensions;

public static class ResultExtensions
{
    public static ApiResponse<T> ToApiResponse<T>(this Result<T> result)
        => new()
        {
            Success = result.IsSuccess,
            Data = result.IsSuccess ? result.Value : default,
            Errors = result.IsFailure ? result.Errors : [],
            StatusCode = result.IsSuccess ? 200 : (result.Errors.Count > 0 ? result.Errors[0].ErrorType.ToHttpStatus() : 500)
        };

    public static ApiResponse<object?> ToApiResponse(this Result result)
        => new()
        {
            Success = result.IsSuccess,
            Data = null,
            Errors = result.IsFailure ? result.Errors : [],
            StatusCode = result.IsSuccess ? 200 : (result.Errors.Count > 0 ? result.Errors[0].ErrorType.ToHttpStatus() : 500)
        };
}
