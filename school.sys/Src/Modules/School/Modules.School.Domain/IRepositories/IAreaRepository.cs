using Modules.School.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.IRepositories
{
    public interface IAreaRepository
    {
        Task<IEnumerable<LocationDTO>> GetByIdAsync(Guid cityId);
    }
}
