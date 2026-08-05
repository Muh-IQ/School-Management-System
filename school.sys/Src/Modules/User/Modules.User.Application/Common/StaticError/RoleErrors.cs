namespace Modules.User.Application.Common.StaticError
{
    public static class RoleErrors
    {

        public static string UnauthorizedMessage()
            => "You are not authorized to perform this operation.";

        public static string UnauthorizedMessage(Guid id)
            => $"You are not authorized to access role with ID '{id}'.";

        public static string UnauthorizedMessage(string code)
            => $"You are not authorized to access role '{code}'.";


        public static string NotFoundMessage()
            => "Role was not found.";

        public static string NotFoundMessage(Guid id)
            => $"Role with ID '{id}' was not found.";

        public static string NotFoundMessage(string code)
            => $"Role with code '{code}' was not found.";

        public static string AlreadyExistsMessage()
            => "Role already exists.";

        public static string AlreadyExistsMessage(Guid id)
            => $"Role with ID '{id}' already exists.";

        public static string CodeAlreadyExistsMessage(string code)
            => $"A role with code '{code}' already exists.";

        public static string InvalidCodeMessage(string code)
            => $"'{code}' is not a valid role code.";

        public static string InvalidNameMessage()
            => "Role name is invalid.";


        public static string CreateFailedMessage()
            => "Failed to create the role.";

        public static string UpdateFailedMessage()
            => "Failed to update the role.";

        public static string DeleteFailedMessage()
            => "Failed to delete the role.";

        public static string AssignFailedMessage()
            => "Failed to assign the role.";

        public static string UnassignFailedMessage()
            => "Failed to remove the role assignment.";

        public static string UnexpectedMessage()
            => "An unexpected error occurred while processing the role.";

        public static string ServiceUnavailableMessage()
            => "The role service is currently unavailable.";

        public static string TimeoutMessage()
            => "The request timed out while processing the role.";
    }
}
