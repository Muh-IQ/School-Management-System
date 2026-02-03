using Modules.School.Domain.Entities;

namespace Modules.School.Domain.IRepositories
{
    public interface ISchoolRepository
    {
        Task<Domain.Entities.School?> GetByIdWithDetailsAsync(Guid schoolId);

        Task<IEnumerable<Domain.Entities.School>> GetActiveSchoolsAsync();

        Task<IEnumerable<Domain.Entities.School>> GetSchoolsAsync(int page,int pageSize,string? searchTerm);

        Task<bool> CanDeleteAsync(Guid schoolId);

        Task SoftDeleteAsync(Guid schoolId);

        Task<Domain.Entities.School?> GetBySanitizedNameAsync(string sanitizeName);

        Task<bool> ExistsAsync(string name);
        
        Task<IEnumerable<Domain.Entities.School>> GetByLanguageAsync(Guid languageId);

        
        Task<IEnumerable<Domain.Entities.School>> GetByPolicyAsync(Guid policyId);

        
        Task<bool> CanUpdateAsync(Guid schoolId, string newName);

        
        Task SetActiveStatusAsync(Guid schoolId, bool isActive);

        
        Task<int> GetTotalCountActiveSchoolsAsync();
    }

}

