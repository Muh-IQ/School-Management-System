using Modules.IdP.Application.Common.DTOs;
using Modules.IdP.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.IServices
{
    public interface IUserService
    {
        Task<Result> AddAsync(AddUserDTO dTO);
        Task<Result> UpdateAsync(UpdateUserDTO dto);
        Task<Result> ValidatePhoneUniquenessAsync(string phone);
        Task<Result> ValidateEmailUniquenessAsync(string email);
    }
}
