using Modules.School.Domain.Entities;

namespace Modules.School.Infrastructure.Persistent.seed
{
    public static class DefaultData
    {
        public static Policy DefaultPolicy = new Policy
        {
            Id = Guid.NewGuid(),
            Title = "Master Policy",
            sanitizeName = "master-policy",
            Description = "This policy applies to all schools by default.",
            PolicyType = "Master",
            IsActive = true,
            IsDeleted = false
        };

    }
}
