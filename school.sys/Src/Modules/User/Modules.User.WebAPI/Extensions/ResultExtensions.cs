using Microsoft.AspNetCore.Mvc;
using Modules.User.Application.Common.Results;

namespace Modules.User.WebAPI.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToHttpResult(this Result result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(
                    new
                    {
                        success = true
                    });
            }

            return new ObjectResult(
                new
                {
                    success = false,
                    message = result.MainError.Message,
                    errors = result.Errors.Select(error => new
                    {
                        type = error.ErrorType.ToString(),
                        message = error.Message
                    })
                })
            {
                StatusCode = (int)result.MainError.ErrorType
            };
        }

        public static IActionResult ToHttpResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(
                    new
                    {
                        success = true,
                        data = result.Value
                    });
            }

            return new ObjectResult(
                new
                {
                    success = false,
                    message = result.MainError.Message,
                    errors = result.Errors.Select(error => new
                    {
                        type = error.ErrorType.ToString(),
                        message = error.Message
                    })
                })
            {
                StatusCode = (int)result.MainError.ErrorType
            };
        }
    }
}
