using Modules.User.Application.Common.DTOs;
using Modules.User.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.IServices
{
    public interface IUserService
    {
        Task<Result> AddAsync(AddUserDTO dTO);
        Task<Result> IsPhoneExistsAsync(string phone);
        Task<Result> IsEmailExistsAsync(string email);
    }
}
