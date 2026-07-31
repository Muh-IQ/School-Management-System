using Modules.User.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.IRepositories
{
    public interface IUserRepository: IGenericRepository<Entities.User>
    {
        Task<IEnumerable<DTOs.UserDto>> GetUsersAsync(int page, int pageSize);

    }
}
