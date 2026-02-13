using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;

namespace Modules.School.Domain.IRepositories
{
    public interface ISchoolRepository
    {
        Task<SchoolDTO?> GetByIdAsDtoAsync(Guid id);
        Task<IEnumerable<SchoolDTO>> GetAllAsDtoAsync(int paging = 1, int pageSize = 10);
        Task<IEnumerable<Domain.Entities.School>> GetActiveSchoolsAsync();

        Task SoftDeleteAsync(Guid schoolId);

        Task<Domain.Entities.School?> GetBySanitizedNameAsync(string sanitizeName);
        
        Task<IEnumerable<Domain.Entities.School>> GetByLanguageAsync(Guid languageId);

        
        Task<IEnumerable<Domain.Entities.School>> GetByPolicyAsync(Guid policyId);

        
        Task SetActiveStatusAsync(Guid schoolId, bool isActive);

        
        Task<int> GetTotalCountActiveSchoolsAsync();
    }

}

