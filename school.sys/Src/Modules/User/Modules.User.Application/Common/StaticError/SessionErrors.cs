namespace Modules.User.Application.Common.StaticError
{
    public static class SessionErrors
    {
        public static string UnauthorizedMessage()
            => "You are not authorized to perform this session operation.";

        public static string UnauthorizedMessage(string sessionKey)
            => $"You are not authorized to access session '{sessionKey}'.";
       
        public static string NotFoundMessage()
            => "Session was not found.";

        public static string NotFoundMessage(string sessionKey)
            => $"Session with key '{sessionKey}' was not found.";

        public static string AlreadyExistsMessage()
            => "Session already exists.";

        public static string AlreadyExistsMessage(string sessionKey)
            => $"A session with key '{sessionKey}' already exists.";

        public static string MissingSessionKeyMessage()
            => "Session key is required.";

        public static string InvalidSessionKeyMessage()
            => "Session key is invalid.";

        public static string InvalidSessionKeyMessage(string sessionKey)
            => $"'{sessionKey}' is not a valid session key.";

        public static string ExpiredMessage()
            => "Session has expired.";

        public static string ExpiredMessage(string sessionKey)
            => $"Session with key '{sessionKey}' has expired.";

        public static string VerificationCodeRequiredMessage()
            => "Verification code is required.";

        public static string InvalidVerificationCodeMessage()
            => "Verification code is invalid.";

        public static string InvalidVerificationCodeMessage(string verificationCode)
            => $"'{verificationCode}' is not a valid verification code.";

        public static string VerficationCoseNotFoundMessage()
           => "Not found verfication code";
        public static string VerificationCodeExpiredMessage()
            => "Verification code has expired.";

        public static string OldEmailNotConfirmedMessage()
            => "The old email address has not been confirmed.";

        public static string NewEmailRequiredMessage()
            => "New email address is required.";

        public static string InvalidNewEmailMessage(string email)
            => $"'{email}' is not a valid new email address.";

        public static string NewEmailAlreadyExistsMessage(string email)
            => $"A user with new email address '{email}' already exists.";

        public static string NewEmailNotConfirmedMessage()
            => "The new email address has not been confirmed.";

        public static string CreateFailedMessage()
            => "Failed to create the session.";

        public static string UpdateFailedMessage()
            => "Failed to update the session.";

        public static string DeleteFailedMessage()
            => "Failed to delete the session.";

        public static string OpenFailedMessage()
            => "Failed to open the session.";

        public static string SendVerificationCodeFailedMessage()
            => "Failed to send the verification code.";

        public static string VerifyFailedMessage()
            => "Failed to verify the session.";

        public static string WriteNewEmailFailedMessage()
            => "Failed to save the new email address.";

        public static string ResetEmailFailedMessage()
            => "Failed to reset the email address.";

        public static string UnexpectedMessage()
            => "An unexpected error occurred while processing the session.";

        public static string ServiceUnavailableMessage()
            => "The session service is currently unavailable.";

        public static string TimeoutMessage()
            => "The request timed out while processing the session.";
    }
}
