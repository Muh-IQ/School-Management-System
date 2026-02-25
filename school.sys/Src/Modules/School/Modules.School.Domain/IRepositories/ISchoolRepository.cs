using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities;

namespace Modules.School.Domain.IRepositories
{
    public interface ISchoolRepository : IGenericRepository<Domain.Entities.School>
    {
        Task<SchoolDetailsDTO?> GetByIdAsDtoAsync(Guid id);
        Task<IEnumerable<SchoolListItemDTO>> GetPagedAsDtoAsync(int pageNumber = 1, int pageSize = 10);
        

    }

}

