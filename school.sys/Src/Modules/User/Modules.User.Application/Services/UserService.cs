
using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using Modules.User.Application.IServices;
using Modules.User.Domain.IRepositories;
using System.Numerics;

namespace Modules.User.Application.Services
{
    public class UserService(IUserRepository userRepository, IRoleService roleService,
        IGenericRepository<Domain.Entities.User> genericRepository, ICacheService cacheService) : IUserService
    {
        public Task<Result> AddAsync(AddUserDTO dTO)
        {

            throw new NotImplementedException();
        }

        public Task<Result> IsEmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result> IsPhoneExistsAsync(string phone)
        {
            throw new NotImplementedException();
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