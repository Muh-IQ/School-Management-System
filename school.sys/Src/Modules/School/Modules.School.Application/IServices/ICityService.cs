using Modules.School.Domain.Common.Results;
using Modules.School.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface ICityService
    {
        public Task<Result<IEnumerable<LocationDTO>>> GetAllByIdAsync(Guid countryID);
    }
}
