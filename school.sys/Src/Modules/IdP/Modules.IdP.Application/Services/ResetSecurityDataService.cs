using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.Sessions;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.IServices;
using Modules.IdP.Domain.IRepositories;

namespace Modules.IdP.Application.Services
{
    public class ResetSecurityDataService( ISessionService sessionService,
    IVerificationCodeService verificationCodeService,
    IGenericRepository<Domain.Entities.User> userRepository) : IResetSecurityDataService
    {
        private readonly TimeSpan SessionExpiration =TimeSpan.FromMinutes(30);

        #region Email

        public async Task<Result<string>>OpenResetEmailSessionAsync(Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);

            if (user is null)
            {
                return Result<string>.Failure(ErrorType.NotFound,UserErrors.NotFoundMessage(userId));
            }

            var session = new ResetEmailSession
            {
                UserId = user.Id,
                OldEmail = user.Email!,
                NewEmail = null,
                IsOldEmailVerified = false,
                IsNewEmailVerified = false
            };

            var key = await sessionService.CreateAsync(session,SessionExpiration);

            return Result<string>.Success(key);
        }


        public async Task<Result>SendResetEmailOldEmailCodeAsync(string sessionKey)
        {
            var result =await sessionService.GetAsync<ResetEmailSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            await verificationCodeService.SendAsync(sessionKey,session.OldEmail);

            return Result.Success();
        }

        public async Task<Result> VerifyEmailResetAsync(string sessionKey, string otp)
        {
            var result = await sessionService.GetAsync<ResetEmailSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            // New email verification cannot happen before old email verification
            if (!string.IsNullOrEmpty(session.NewEmail) && !session.IsOldEmailVerified)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.OldEmailNotConfirmedMessage());
            }

            // Verify OTP
            var verifyResult = await verificationCodeService.VerifyAsync(sessionKey, otp);

            if (verifyResult.IsFailure)
                return verifyResult;

            // Determine verification target from session
            if (string.IsNullOrEmpty(session.NewEmail))
            {
                session.IsOldEmailVerified = true;
            }
            else
            {
                session.IsNewEmailVerified = true;
            }

            await sessionService.UpdateAsync(sessionKey, session, SessionExpiration);


            return Result.Success();
        }

        public async Task<Result>WriteNewEmailAsync(string sessionKey,string newEmail)
        {
            var result =await sessionService.GetAsync<ResetEmailSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            if (!session.IsOldEmailVerified)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.OldEmailNotConfirmedMessage());
            }

            if (string.IsNullOrWhiteSpace(newEmail))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailRequiredMessage());
            }

            var exists = await userRepository.ExistsAsync(x => x.Email == newEmail);

            if (exists)
            {
                return Result.Failure(ErrorType.Conflict,UserErrors.EmailAlreadyExistsMessage(newEmail));
            }

            session.NewEmail = newEmail;
            session.IsNewEmailVerified = false;

            await sessionService.UpdateAsync(sessionKey,session,SessionExpiration);

            return Result.Success();
        }


        public async Task<Result>SendResetEmailNewEmailCodeAsync(string sessionKey)
        {
            var result =await sessionService.GetAsync<ResetEmailSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            if (!session.IsOldEmailVerified)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.OldEmailNotConfirmedMessage());
            }

            if (string.IsNullOrWhiteSpace(session.NewEmail))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailRequiredMessage());
            }

            await verificationCodeService.SendAsync(sessionKey,session.NewEmail);

            return Result.Success();
        }


       


        public async Task<Result>ResetEmailAsync(string sessionKey)
        {
            var result =await sessionService.GetAsync<ResetEmailSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            if (!session.IsOldEmailVerified)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.OldEmailNotConfirmedMessage());
            }

            if (!session.IsNewEmailVerified)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailNotConfirmedMessage());
            }

            if (string.IsNullOrWhiteSpace(session.NewEmail))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailRequiredMessage());
            }

            var user =await userRepository.GetByIdAsync(session.UserId);

            if (user is null)
            {
                return Result.Failure(ErrorType.NotFound,UserErrors.NotFoundMessage(session.UserId));
            }

            user.Email = session.NewEmail;

            var updated =await userRepository.UpdateAsync(user);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError,UserErrors.UpdateFailedMessage());
            }

            await sessionService.RemoveAsync(sessionKey);

            return Result.Success();
        }

        #endregion

        #region Password

        public async Task<Result<string>>OpenResetPasswordSessionAsync(Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);

            if (user is null)
            {
                return Result<string>.Failure(ErrorType.NotFound,UserErrors.NotFoundMessage(userId));
            }

            var session = new ResetPasswordSession
            {
                UserId = user.Id,
                CurrentEmail = user.Email!,
                IsEmailVerified = false
            };

            var key = await sessionService.CreateAsync(session,SessionExpiration);

            return Result<string>.Success(key);
        }


        public async Task<Result>SendResetPasswordEmailCodeAsync(string sessionKey)
        {
            var result =await sessionService.GetAsync<ResetPasswordSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            await verificationCodeService.SendAsync(sessionKey,session.CurrentEmail);

            return Result.Success();
        }


        public async Task<Result>VerifyResetPasswordEmailAsync(string sessionKey,string otp)
        {
            var result =await sessionService.GetAsync<ResetPasswordSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            var verifyResult =await verificationCodeService.VerifyAsync(sessionKey,otp);

            if (verifyResult.IsFailure)
                return verifyResult;

            session.IsEmailVerified = true;

            await sessionService.UpdateAsync(sessionKey,session,SessionExpiration);

            return Result.Success();
        }


        public async Task<Result>ResetPasswordAsync(string sessionKey,string newPassword)
        {
            var result =await sessionService.GetAsync<ResetPasswordSession>(sessionKey);

            if (result.IsFailure)
                return result;

            var session = result.Value;

            if (!session.IsEmailVerified)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.CurrentEmailNotConfirmedMessage());
            }

            var user =await userRepository.GetByIdAsync(session.UserId);

            if (user is null)
            {
                return Result.Failure(ErrorType.NotFound,UserErrors.NotFoundMessage(session.UserId));
            }

            user.Password = newPassword;

            var updated =await userRepository.UpdateAsync(user);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError,UserErrors.UpdateFailedMessage());
            }

            await sessionService.RemoveAsync(sessionKey);

            return Result.Success();
        }

        #endregion
    }
}
