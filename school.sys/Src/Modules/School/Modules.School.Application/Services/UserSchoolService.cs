using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using Modules.School.Domain.IThirdPartyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Services
{
    public class UserSchoolService(IGenericRepository<UserSchool> genericRepository,ITimeProvider timeProvider) : IUserSchoolService
    {
        public async Task<Result> AddAsync(Guid userId, Guid SchoolId)
        {

            var user = new UserSchool()
            {
                UserId = userId,
                SchoolId = SchoolId,
                IsActive = true,
                IsDeleted = false,
                CreateAt = timeProvider.UtcNow,
                UpdateAt = null
            };

            var result = await genericRepository.AddAsync(user);

            if(result==false)
            {
                return Result.Failure(ErrorType.InternalServerError,UserErrors.InternalServerErrorMessage() ); 
            }

            return Result.Success();
        }
    }
}
