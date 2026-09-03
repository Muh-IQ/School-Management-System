using Modules.IdP.Application.Common.DTOs;
using Modules.IdP.Application.Common.Results;

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
