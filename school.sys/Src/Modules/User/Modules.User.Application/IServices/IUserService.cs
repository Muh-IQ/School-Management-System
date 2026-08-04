using Modules.User.Domain.Common.Results;
using Modules.User.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.IServices
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDto>>> GetUsersAsync(int page, int pageSize);

        Task<Result<UserDto>> GetByIdAsync(Guid id);

        Task<Result> CreateAsync(CreateUserDTO createUser);

        //Task<Result> UpdateAsync(UpdateUserDTO updateUser);
        //Task<Result> DeleteAsync(Guid id);
    }
}
