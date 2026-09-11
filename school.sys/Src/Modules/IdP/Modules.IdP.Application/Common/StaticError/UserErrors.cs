namespace Modules.IdP.Application.Common.StaticError
{
    public static class UserErrors
    {
        public static string AccountLockedMessage()
    => "Account is locked due to too many failed login attempts.";
        public static string InvalidCredentialsMessage() 
            => "Invalid email or password.";
        public static string UnauthorizedMessage(Guid id)
            => $"User with ID '{id}' is not authorized to perform this operation.";

        public static string UnauthorizedMessage(string username)
            => $"User '{username}' is not authorized to perform this operation.";

        public static string NotFoundMessage()
            => "User was not found.";

        public static string NotFoundMessage(Guid id)
            => $"User with ID '{id}' was not found.";

        public static string AlreadyExistsMessage()
            => "User already exists.";

        public static string AlreadyExistsMessage(Guid id)
            => $"User with ID '{id}' already exists.";

        public static string EmailAlreadyExistsMessage(string email)
            => $"A user with email '{email}' already exists.";

        public static string PhoneAlreadyExistsMessage(string phone)
            => $"A user with phone number '{phone}' already exists.";

        public static string InvalidEmailMessage(string email)
            => $"'{email}' is not a valid email address.";

        public static string InvalidPhoneMessage(string phone)
            => $"'{phone}' is not a valid phone number.";

        public static string InvalidNameMessage()
            => "User name is invalid.";

        public static string InvalidDateOfBirthMessage()
            => "Date of birth is invalid.";


        public static string CreateFailedMessage()
            => "Failed to create the user.";

        public static string UpdateFailedMessage()
            => "Failed to update the user.";

        public static string DeleteFailedMessage()
            => "Failed to delete the user.";

        public static string ActivateFailedMessage()
            => "Failed to activate the user.";

        public static string DeactivateFailedMessage()
            => "Failed to deactivate the user.";

        public static string UnexpectedMessage()
            => "An unexpected error occurred while processing the user.";

        public static string ServiceUnavailableMessage()
            => "The user service is currently unavailable.";

        public static string TimeoutMessage()
            => "The request timed out while processing the user.";
    }
}
