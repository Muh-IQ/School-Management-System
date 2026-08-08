
using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using Modules.User.Application.Helpers;
using Modules.User.Application.IServices;
using Modules.User.Domain.Entities;
using Modules.User.Domain.IRepositories;
using Modules.User.Domain.Utilities;
using SharedKernel;
using SharedKernel.Events;
using System.Numerics;

namespace Modules.User.Application.Services
{
    public class UserService(IEventBus @event, IRoleService roleService, IUnitOfWork UoF,
        IGenericRepository<Domain.Entities.User> genericRepository, ICacheService cacheService) : IUserService
    {
        public async Task<Result> AddAsync(AddUserDTO dto)
        {
            var validation = await ValidateUserAsync(dto);

            if (validation.IsFailure)
                return validation;

            var role = await roleService.GetByCodeAsync(RoleCodes.SchoolAdmin);

            var userId = Guid.NewGuid();

            await UoF.Users.StageInsert(UserHelper.CreateUser(dto, userId));
            await UoF.UserRoles.StageInsert(UserHelper.CreateUserRole(userId, role.Value.Id));


            //I must tell the school module to assign the user to the school.
            await @event.PublishAsync<UserRegisteredIntegrationEvent>(new UserRegisteredIntegrationEvent(userId, dto.SchoolID));
            
            
            // I must send an email to the user with his credentials and a link to set his password.
            return await UoF.SaveChangesAsync() > 0
                ? Result.Success()
                : Result.Failure(ErrorType.InternalServerError, "Failed to add user");
        }

        public async Task<Result> ValidateEmailUniquenessAsync(string email)
        {
            bool res = await cacheService.GetOrCreateAsync($"SEARCH-Email-{email}", async () =>
            {
                var user = await genericRepository.ExistsAsync(e => e.Email == email);
                return user != null;
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
                var user = await genericRepository.ExistsAsync(ph => ph.Phone == phone);
                return user != null;
            }, TimeSpan.FromMinutes(10));

            if (res)
            {
                return Result.Failure(ErrorType.Conflict, "Phone already exists");
            }
            return Result.Success();
        }


        private async Task<Result> ValidateUserAsync(AddUserDTO dto)
        {
            var emailValidation = await ValidateEmailUniquenessAsync(dto.Email);
            var phoneValidation = await ValidatePhoneUniquenessAsync(dto.Phone);

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