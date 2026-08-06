//using Microsoft.AspNetCore.Mvc;
//using Modules.User.Domain.Common.Results;
//using Modules.User.Application.Common.Results;
//using Modules.User.WebAPI.Mapping;

//namespace Modules.User.WebAPI.Extensions
//{
//    public static class ResultExtensions
//    {
//        public static IActionResult ToHttpResult(this Result result)
//        {
//            if (result.IsSuccess)
//                return new OkResult();

//            var statusCode = ErrorMapping.ToStatusCode(result.Error);
//            var statusCode = ErrorMapping.ToStatusCode(result.Errors);

//            return new ObjectResult(new ProblemDetails
//            {
//                Title = result.Error.Code,
//                Detail = result.Error.Message,
//                Status = statusCode
//            })
//            {
//                StatusCode = statusCode
//            };
//        }

//        public static IActionResult ToHttpResult<T>(this Result<T> result)
//        {
//            if (result.IsSuccess)
//                return new OkObjectResult(result.Value);

//            var statusCode = ErrorMapping.ToStatusCode(result.Error);

//            return new ObjectResult(new ProblemDetails
//            {
//                Title = result.Error.Code,
//                Detail = result.Error.Message,
//                Status = statusCode
//            })
//            {
//                StatusCode = statusCode
//            };
//        }
//    }
//}
