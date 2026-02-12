using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Common.StaticError
{
    public static class UserErrors
    {
        public static string NoneMessage()
        {
            return "Empty data";
        }

        public static string BadRequestMessage()
        {
            return "The request could not be processed due to invalid input.";
        }

        public static string UnauthorizedMessage(string? username = null)
        {
            return username == null
                ? "You are not authorized to perform this operation."
                : $"User '{username}' is not authorized to perform this operation.";
        }
        public static string UnauthorizedMessage(Guid? Id = null)
        {
            return Id == null
                ? "You are not authorized to perform this operation."
                : $"User '{Id}' is not authorized to perform this operation.";
        }

        public static string ForbiddenMessage(string action = "")
        {
            return string.IsNullOrWhiteSpace(action)
                ? "Access denied. You do not have sufficient permissions."
                : $"Access denied. You do not have permission to {action}.";
        }

        public static string NotFoundMessage(Guid? id = null)
        {
            return id == null
                ? $"User was not found."
                : $"User with ID '{id}' was not found.";
        }

        public static string ConflictMessage(Guid? ExistsId = null, string? ExistsName = null)
        {
            if (ExistsId != null)
            {
                return $"The operation could not be completed due to a conflict with entity with ID '{ExistsId}'";
            }
            else if (ExistsName != null)
            {
                return $"The operation could not be completed due to a conflict with entity with Name '{ExistsName}'";
            }

            return $"The operation could not be completed due to a conflict.";
        }

        public static string TimeoutMessage()
        {
            return "The operation timed out. Please try again later.";
        }

        public static string ValidationMessage(string fieldName = "")
        {
            return string.IsNullOrWhiteSpace(fieldName)
                ? "The request failed validation. Please check the input data."
                : $"Validation failed for field '{fieldName}'. Please provide a valid value.";
        }

        public static string InternalServerErrorMessage()
        {
            return "There was a server error. Please try again later.";
        }

        public static string ServiceUnavailableMessage()
        {
            return "The service is currently unavailable. Please try again later.";
        }


    }
}
