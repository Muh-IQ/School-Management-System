namespace Modules.IdP.Application.Common.StaticError
{
    public static class UserRoleErrors
    {
        public static string AlreadyAssignedMessage()
        => "The role is already assigned to the user.";

        public static string AlreadyAssignedMessage(Guid userId, Guid roleId)
            => $"Role '{roleId}' is already assigned to user '{userId}'.";

        public static string AssignmentNotFoundMessage()
            => "The specified role assignment does not exist.";

        public static string AssignmentNotFoundMessage(Guid userId, Guid roleId)
            => $"User '{userId}' does not have role '{roleId}' assigned.";
        public static string AssignFailedMessage()
       => "Failed to assign the role to the user.";
        public static string RemoveFailedMessage()
        => "Failed to remove the role from the user.";
        public static string UnexpectedMessage()
       => "An unexpected error occurred while processing the user role assignment.";

    }
}
