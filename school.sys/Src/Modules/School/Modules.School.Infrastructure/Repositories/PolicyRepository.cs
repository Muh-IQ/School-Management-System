using Modules.School.Domain.IRepositories;

namespace Modules.School.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        Task<Guid> IPolicyRepository.GetDefaultPolicyIdAsync()
        {
        }
    }
}
