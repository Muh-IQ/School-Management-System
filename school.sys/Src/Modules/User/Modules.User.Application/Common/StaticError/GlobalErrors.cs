using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Common.StaticError
{
    public static class GlobalErrors
    {
        public static string NoneMessage()
        => "Empty data.";

        public static string BadRequestMessage()
            => "The request could not be processed due to invalid input.";

        public static string ValidationMessage()
            => "One or more validation errors occurred.";

        public static string UnauthorizedMessage()
            => "You are not authorized to perform this operation.";

        public static string ForbiddenMessage()
            => "Access denied. You do not have sufficient permissions.";
        public static string ForbiddenMessage(string action)
    => $"Access denied. You do not have permission to {action}.";
        public static string NotFoundMessage()
            => "The requested resource was not found.";

        public static string ConflictMessage()
            => "The requested operation could not be completed due to a conflict.";

        public static string TimeoutMessage()
            => "The request timed out.";

        public static string InternalServerErrorMessage()
            => "An internal server error occurred.";

        public static string ServiceUnavailableMessage()
            => "The service is currently unavailable. Please try again later.";

        public static string UnexpectedMessage()
            => "An unexpected error occurred.";

        public static string OperationFailedMessage()
            => "The operation failed.";

        public static string CreateFailedMessage()
            => "Failed to create the resource.";

        public static string UpdateFailedMessage()
            => "Failed to update the resource.";

        public static string DeleteFailedMessage()
            => "Failed to delete the resource.";

        public static string SaveFailedMessage()
            => "Failed to save changes.";

        public static string InvalidOperationMessage()
            => "The requested operation is invalid.";

        public static string DuplicateMessage()
            => "The resource already exists.";

        public static string DatabaseErrorMessage()
            => "A database error occurred.";

        public static string ConcurrencyMessage()
            => "The resource was modified by another process. Please reload and try again.";

        public static string NullValueMessage(string fieldName)
            => $"'{fieldName}' cannot be null.";

        public static string RequiredFieldMessage(string fieldName)
            => $"'{fieldName}' is required.";

        public static string InvalidValueMessage(string fieldName)
            => $"'{fieldName}' has an invalid value.";

        public static string MaxLengthMessage(string fieldName, int maxLength)
            => $"'{fieldName}' cannot exceed {maxLength} characters.";

        public static string MinLengthMessage(string fieldName, int minLength)
            => $"'{fieldName}' must be at least {minLength} characters.";

        public static string RangeMessage(string fieldName, object min, object max)
            => $"'{fieldName}' must be between {min} and {max}.";
    }
}
