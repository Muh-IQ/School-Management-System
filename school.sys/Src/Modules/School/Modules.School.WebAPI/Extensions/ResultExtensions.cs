using Microsoft.AspNetCore.Mvc;
using Modules.School.Domain.Common.Results;
using Modules.School.WebAPI.Contracts;

namespace Modules.School.WebAPI.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToApiResponse(this Result result, int successStatusCode = 200)
    {
        if (result.IsSuccess)
        {
            return new ObjectResult(ApiResponse.Ok()) { StatusCode = successStatusCode };
        }

        return HandleErrorResponse(result.Errors);
    }

    public static IActionResult ToApiResponse<T>(this Modules.School.Domain.Common.Results.Result<T> result, int successStatusCode = 200)
    {
        if (result.IsSuccess)
        {
            return new ObjectResult(ApiResponse<T>.Ok(result.Value!)) { StatusCode = successStatusCode };
        }

        return HandleErrorResponse(result.Errors);
    }

    private static IActionResult HandleErrorResponse(List<Error> Errors)
    {
        (List<string> errors, ErrorType errorType) = PreperErrorsMessages(Errors);

        var response = ApiResponse.Fail(
            message: "Operation Failed",
            errors: errors
        );
        // convert ErrorType to corresponding IActionResult
        return new ObjectResult(response) { StatusCode = (int)errorType };
    }


    private static (List<string> Errors , ErrorType errorType)  PreperErrorsMessages(List<Error> errors)
    {
        var ErrorMessages = new List<string>();
        ErrorType errorType = ErrorType.None;
        foreach (var error in errors)
        {
            if ((int)error.ErrorType >= 500)
            {
                ErrorMessages.Add("An internal error occurred. Please try again later.");
                errorType = error.ErrorType; // Set the error type for 500 errors
            }
            else
            {
                if ((int)errorType < 500)
                {
                    errorType = error.ErrorType;
                }
                ErrorMessages.Add(error.Message);
            }
        }

        return (ErrorMessages , errorType);
    }
}


