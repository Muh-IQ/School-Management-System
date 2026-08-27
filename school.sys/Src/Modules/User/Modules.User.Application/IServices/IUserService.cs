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
        Task<Result<OpenSessionResponse>> OpenSessionAsync();
        Task<Result> SendVerficationCodeUserAsync(string sessionKey);
        Task<Result> VerifyUserAsync(string otp, string sessionKey);
        
        Task<Result> WriteNewEmailAsync(string sessionKey, string newEmail);
        Task<Result> ResetEmailAsync(string sessionKey);

        Task<Result> AddAsync(AddUserDTO dTO);
        Task<Result> UpdateAsync(UpdateUserDTO dto);
        Task<Result> ValidatePhoneUniquenessAsync(string phone);
        Task<Result> ValidateEmailUniquenessAsync(string email);
    }
}
