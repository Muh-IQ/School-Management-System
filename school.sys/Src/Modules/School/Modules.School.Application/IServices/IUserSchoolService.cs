using Modules.School.Domain.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.IServices
{
    public interface IUserSchoolService
    {
        Task<Result> AddAsync(Guid userId,Guid SchoolId);
    }
}
