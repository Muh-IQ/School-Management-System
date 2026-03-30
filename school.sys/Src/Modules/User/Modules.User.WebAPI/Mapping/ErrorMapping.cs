using Modules.User.Domain.Common.Results;

namespace Modules.User.WebAPI.Mapping
{
    public static class ErrorMapping
    {
        private static readonly Dictionary<string, int> ErrorMap = new()
        {

            // ---------- User ----------
            ["User.NotFound"] = StatusCodes.Status404NotFound,
            ["User.AlreadyExists"] = StatusCodes.Status409Conflict,

            // ---------- Email ----------
            ["User.EmailRequired"] = StatusCodes.Status400BadRequest,
            ["User.InvalidEmail"] = StatusCodes.Status400BadRequest,
            ["User.DuplicateEmail"] = StatusCodes.Status409Conflict,

            // ---------- Password ----------
            ["User.InvalidPassword"] = StatusCodes.Status400BadRequest,

            // ---------- Authentication ----------
            ["User.InvalidCredentials"] = StatusCodes.Status401Unauthorized,
            ["User.Unauthorized"] = StatusCodes.Status403Forbidden,

            // ---------- Account ----------
            ["User.AccountLocked"] = StatusCodes.Status403Forbidden,
            ["User.AccountInactive"] = StatusCodes.Status403Forbidden,

            // ---------- Server ----------
            ["Database.SaveFailed"] = StatusCodes.Status500InternalServerError,
            ["Database.DeleteFailed"] = StatusCodes.Status500InternalServerError,
            ["Database.UpdateFailed"] = StatusCodes.Status500InternalServerError

        };

        public static int ToStatusCode(Error error)
        {
            return ErrorMap.TryGetValue(error.Code, out var status)
                ? status
                : StatusCodes.Status400BadRequest;
        }
    }
}
