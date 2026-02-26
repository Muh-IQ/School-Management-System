using Modules.School.Domain.Entities;

namespace Modules.School.Infrastructure.Persistent.seed
{
    public static class DefaultData
    {
        public static Policy DefaultPolicy = new Policy
        {
            Id = Guid.NewGuid(),
            Title = "General School Policy",
            Description = "This policy defines the general operational and behavioral guidelines applicable to all schools unless otherwise specified.",
            sanitizeName = "general-school-policy",
            IsActive = true,
            IsDeleted = false,
            IsDefault = true
        };

    }
}
