using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using Modules.User.Application.Common.StaticError;
using Modules.User.Application.Helpers;
using Modules.User.Application.IServices;
using Modules.User.Domain.BatchRecord;
using Modules.User.Domain.Entities;
using Modules.User.Domain.IRepositories;
using Modules.User.Domain.Utilities;
using SharedKernel;
using SharedKernel.Events;
using System.Numerics;

namespace Modules.User.Application.Services
{
    public class UserService(IEventBus @event, IRoleService roleService, MicroBatch<UserRegistrationBatchItem> userBatcher,
        IGenericRepository<Domain.Entities.User> genericRepository, ICacheService cacheService) : IUserService
    {
        private readonly string MockOldEmailToken = "addh3584@gmail.com";
        private readonly Guid MockOldUserId = Guid.Parse("0a0f30a5-0f5b-4b91-50e5-08de8cf2783a");
        private async Task<Result<ResetEmailSession>> GetSessionAsync(string sessionKey)
        {
            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                return Result<ResetEmailSession>.Failure(ErrorType.BadRequest,SessionErrors.InvalidSessionKeyMessage());
            }

            var session = await cacheService.GetAsync<ResetEmailSession>(sessionKey);

            if (session is null)
            {
                return Result<ResetEmailSession>.Failure(ErrorType.NotFound,SessionErrors.NotFoundMessage(sessionKey));
            }

            return Result<ResetEmailSession>.Success(session);
        }
        public async Task<Result<OpenSessionResponse>> OpenSessionAsync()
        {
            var key=$"RESET-EMAILSESSION-{Guid.NewGuid():N}";
            var session = new ResetEmailSession
            {
                NewEmail = null,
                IsConfirmNewEmail = false,
                IsConfirmOldEmail = false,
                IsNewEmailExist = true,
            };
            await cacheService.SetAsync(key, session, TimeSpan.FromMinutes(15));

            return Result<OpenSessionResponse>.Success(new OpenSessionResponse{ Key = key});
        }
        public async Task<Result> SendVerficationCodeUserAsync(string sessionKey)
        {
            var sessionResult = await GetSessionAsync(sessionKey);

            if (sessionResult.IsFailure)
            {
                return sessionResult;
            }

            var session = sessionResult.Value;

            OTP otp = new OTP();
            string verificationCode = otp.Generate();
            await cacheService.SetAsync(
            $"OTP:{sessionKey}",
            verificationCode,
            TimeSpan.FromMinutes(5));

            await @event.PublishAsync<UserVerifyIntegrationEvent>(new UserVerifyIntegrationEvent(
            session.NewEmail ?? MockOldEmailToken,verificationCode));

            return Result.Success();
        }
        public async Task<Result> VerifyUserAsync(string otp ,string sessionKey)
        {
            var sessionResult = await GetSessionAsync(sessionKey);

            if (sessionResult.IsFailure)
            {
                return sessionResult;
            }

            var session = sessionResult.Value;

            if (string.IsNullOrWhiteSpace(otp))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.VerificationCodeRequiredMessage());
            }

            var storedOtp = await cacheService.GetAsync<string>($"OTP:{sessionKey}");

            if (string.IsNullOrEmpty(storedOtp))
            {
                return Result.Failure(ErrorType.NotFound, SessionErrors.VerficationCoseNotFoundMessage());
            }

            if (storedOtp != otp)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.InvalidVerificationCodeMessage(otp));
            }
            if(string.IsNullOrEmpty( session.NewEmail))
            {
                session.IsConfirmOldEmail = true;
            }
            else
            {
                session.IsConfirmNewEmail = true;
            }

            await cacheService.SetAsync(sessionKey, session, TimeSpan.FromMinutes(15));

            await cacheService.RemoveAsync($"OTP:{sessionKey}");

            return Result.Success();
        }
        
        public async Task<Result> WriteNewEmailAsync(string sessionKey,string newEmail)
        {
            var sessionResult = await GetSessionAsync(sessionKey);

            if (sessionResult.IsFailure)
            {
                return sessionResult;
            }

            var session = sessionResult.Value;

            if (!session.IsConfirmOldEmail)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.OldEmailNotConfirmedMessage());
            }

            if (string.IsNullOrWhiteSpace(newEmail))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailRequiredMessage());
            }

            var emailExists = await genericRepository.ExistsAsync(x => x.Email == newEmail);

            if (emailExists)
            {
                session.IsNewEmailExist = true;

                await cacheService.SetAsync(sessionKey,session,TimeSpan.FromMinutes(15));

                return Result.Failure(ErrorType.Conflict,UserErrors.EmailAlreadyExistsMessage(newEmail));
            }

            session.NewEmail = newEmail;
            session.IsNewEmailExist = false;

            await cacheService.SetAsync(sessionKey,session,TimeSpan.FromMinutes(15));

            return Result.Success();
        }
        public async Task<Result> ResetEmailAsync(string sessionKey)
        {
            var sessionResult = await GetSessionAsync(sessionKey);

            if (sessionResult.IsFailure)
            {
                return sessionResult;
            }

            var session = sessionResult.Value;

            if (!session.IsConfirmOldEmail)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.OldEmailNotConfirmedMessage());
            }

            if (!session.IsConfirmNewEmail)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailNotConfirmedMessage());
            }

            if (session.IsNewEmailExist)
            {
                return Result.Failure(ErrorType.Conflict,UserErrors.EmailAlreadyExistsMessage(session.NewEmail!));
            }

            if (string.IsNullOrWhiteSpace(session.NewEmail))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.NewEmailRequiredMessage());
            }

            var user = await genericRepository.GetByIdAsync(MockOldUserId);

            if (user is null)
            {
                return Result.Failure(ErrorType.NotFound,UserErrors.NotFoundMessage(MockOldUserId));
            }

            user.Email = session.NewEmail;

            var saveResult = await genericRepository.UpdateAsync(user);

            if (!saveResult)
            {
                return Result.Failure(ErrorType.InternalServerError,UserErrors.UpdateFailedMessage());
            }

            await cacheService.RemoveAsync(sessionKey);

            return Result.Success();
        }
        public async Task<Result> UpdateAsync(UpdateUserDTO dto)
        {

            var user = await genericRepository.GetByIdAsync(dto.Id);
            if (user is null)
            {
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }

            if(!string.IsNullOrEmpty(dto.Name) && dto.Name != user.Name)
            {
                user.Name = dto.Name;   
            }
            if (dto.DateOfBirth != default(DateTime) && dto.DateOfBirth != user.DateOfBirth)
            {
                user.DateOfBirth = dto.DateOfBirth;
            }
            if(user.Gender != dto.gender)
            {
                user.Gender = dto.gender;

            }
            user.UpdateAt = DateTime.Now;

            bool result = await genericRepository.UpdateAsync(user);
            if (result) return Result.Success();
            else return Result.Failure(ErrorType.InternalServerError, GlobalErrors.InternalServerErrorMessage());

        }
        public async Task<Result> AddAsync(AddUserDTO dto)
        {
            var validation = await ValidateUserAsync(dto.Email,dto.Phone);
            var role = await roleService.GetByCodeAsync(RoleCodes.SchoolAdmin);

            if (validation.IsFailure)
                return validation;

            var userId = Guid.NewGuid();
            string Password = PasswordHelper.GenerateRandomPassword();
            string HashedPassword = PasswordHelper.HashPassword(Password);

            //Fire-and-forget the user and user role creation, we don't need to wait for them to be created in the database.
            var user =
            UserHelper.CreateUser(dto,userId,HashedPassword);

            var userRole = UserHelper.CreateUserRole(userId,role.Value.Id);

            userBatcher.Add( new UserRegistrationBatchItem( user, userRole));


            await @event.PublishAsync<UserRegisteredIntegrationEvent>(new UserRegisteredIntegrationEvent(userId, dto.SchoolID, dto.Email, Password));

            // I must send an email to the user with his credentials and a link to set his password.
            return Result.Success();
        }
     

        public async Task<Result> ValidateEmailUniquenessAsync(string email)
        {
            bool res = await cacheService.GetOrCreateAsync($"SEARCH-Email-{email}", async () =>
            {
                return await genericRepository.ExistsAsync(e => e.Email == email);
            }, TimeSpan.FromMinutes(10));

            if (res)
            {
                return Result.Failure(ErrorType.Conflict, "Email already exists");
            }
            return Result.Success();
        }

        public async Task<Result> ValidatePhoneUniquenessAsync(string phone)
        {
            bool res = await cacheService.GetOrCreateAsync($"SEARCH-Phone-{phone}", async () =>
            {
                return await genericRepository.ExistsAsync(ph => ph.Phone == phone);
            }, TimeSpan.FromMinutes(10));

            if (res)
            {
                return Result.Failure(ErrorType.Conflict, "Phone already exists");
            }
            return Result.Success();
        }

        private async Task<Result> ValidateUserAsync(string email,string phone)
        {
            var emailValidation = await ValidateEmailUniquenessAsync(email);
            var phoneValidation = await ValidatePhoneUniquenessAsync(phone);

            if (emailValidation.IsFailure && phoneValidation.IsFailure)
            {
                return emailValidation.WithError(
                    phoneValidation.MainError.ErrorType,
                    phoneValidation.MainError.Message);
            }

            if (emailValidation.IsFailure)
                return emailValidation;

            if (phoneValidation.IsFailure)
                return phoneValidation;

            return Result.Success();
        }
    }
}


/*
#business logic for adding a new user:

-check if the input data is valid -> will be done at API level
-check if the user already exists in the database by email or phone number -> so will do it at business level
-generate a new user id -> will be done at business level
-get id of the role by its code -> will be done at business level
-add the user to the database -> will be done at business level
-add the user role to the database -> will be done at business level
-tell the school module to assign the user to the school -> will be done at business level

 */