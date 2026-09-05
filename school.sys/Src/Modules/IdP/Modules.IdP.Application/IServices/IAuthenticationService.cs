using Modules.IdP.Application.Common.Results;
using Modules.IdP.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.IServices
{
    public interface IAuthenticationService
    {
        Result<string> GenerateJWTToken(UserTokenDTO user);
    }
}
