using Modules.IdP.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.IServices
{
    public interface IAuthNService
    {
        Task<Result<string>> GenerateTokenAsync(Guid UserId);
    }
}
