using Modules.User.Application.IServices;
using Modules.User.Application.Mappers;
using Modules.User.Domain.Common.Results;
using Modules.User.Domain.Common.StaticError;
using Modules.User.Domain.DTOs;
using Modules.User.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<Result<IEnumerable<UserDto>>> GetUsersAsync(int page, int pageSize)
        {
            var users = await userRepository.GetUsersAsync(page, pageSize);

            return Result.Success(users);
        }

        public async Task<Result<UserDto>> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user is null)
                return Result.Failure<UserDto>(UserErrors.NotFound);

            return Result.Success(user.ToDto());
        }

        public async Task<Result> CreateAsync(CreateUserDTO createUser)
        {
            var exists = await userRepository.IsExistEmailAsync(createUser.Email);

            if (exists)
                return Result.Failure(UserErrors.DuplicateEmail);

            var user = createUser.ToEntity();

            var success = await userRepository.AddAsync(user);

            if (!success)
                return Result.Failure(DatabaseErrors.SaveFailed);

            return Result.Success();
        }

        //public async Task<Result> UpdateAsync(UpdateUserDTO updateUser)
        //{
        //    var user = await userRepository.GetByIdAsync(updateUser.Id);

        //    if (user is null)
        //        return Result.Failure(UserErrors.NotFound);

        //    if (string.IsNullOrWhiteSpace(updateUser.Email))
        //        return Result.Failure(UserErrors.EmailRequired);


        //    var duplicate = await userRepository.GetByEmailAsync(updateUser.Email);

        //    if (duplicate is not null && duplicate.Id != updateUser.Id)
        //        return Result.Failure(UserErrors.DuplicateEmail);

        //    updateUser.UpdateEntity(user);

        //    var success = await userRepository.UpdateAsync(user);

        //    if (!success)
        //        return Result.Failure(DatabaseErrors.UpdateFailed);

        //    return Result.Success();
        //}

        //public async Task<Result> DeleteAsync(Guid id)
        //{
        //    var user = await userRepository.GetByIdAsync(id);

        //    if (user is null)
        //        return Result.Failure(UserErrors.NotFound);

        //    var success = await userRepository.DeleteAsync(user);

        //    if (!success)
        //        return Result.Failure(DatabaseErrors.DeleteFailed);

        //    return Result.Success();
        //}
    }
}
