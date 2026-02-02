using Modules.School.Domain.Entities;

namespace Modules.School.Domain.IRepositories
{
    public interface ISchoolRepository
    {
        Task<Schools?> GetByIdWithDetailsAsync(Guid schoolId);

        Task<IEnumerable<Schools>> GetActiveSchoolsAsync();

        Task<IEnumerable<Schools>> GetSchoolsAsync(int page,int pageSize,string? searchTerm);

        Task<bool> CanDeleteAsync(Guid schoolId);

        Task SoftDeleteAsync(Guid schoolId);

        Task<Schools?> GetBySanitizedNameAsync(string sanitizeName);

        Task<bool> ExistsAsync(string name);
        
        Task<IEnumerable<Schools>> GetByLanguageAsync(Guid languageId);

        
        Task<IEnumerable<Schools>> GetByPolicyAsync(Guid policyId);

        
        Task<bool> CanUpdateAsync(Guid schoolId, string newName);

        
        Task SetActiveStatusAsync(Guid schoolId, bool isActive);

        
        Task<int> GetTotalCountActiveSchoolsAsync();
    }

}

