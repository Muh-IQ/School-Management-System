using Modules.School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.IRepositories
{
    public interface IPolicyRepository
    {
        Task<Guid> GetDefaultPolicyIdAsync();

    }
}
