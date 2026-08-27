using Modules.IdP.Application.Common.DTOs;
using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.Helpers;
using Modules.IdP.Application.IServices;
using Modules.IdP.Domain.BatchRecord;
using Modules.IdP.Domain.Entities;
using Modules.IdP.Domain.IRepositories;
using Modules.IdP.Domain.Utilities;
using SharedKernel;
using SharedKernel.Events;
using System.Numerics;

namespace Modules.IdP.Application.Services
{
    public class UserService(IEventBus @event, IRoleService roleService, MicroBatch<UserRegistrationBatchItem> userBatcher,
        IGenericRepository<Domain.Entities.User> genericRepository, ICacheService cacheService) : IUserService
    {
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
            if (dto.DateOfBirth != default(DateTime) && dto.DateOfBirth != user.DOB)
            {
                user.DOB = dto.DateOfBirth;
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