using Modules.School.Domain.Entities;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class PolicySeed : IEntitySeed<Policy>
{
    public static readonly Guid MasterPolicyId = new("12112121-2121-2121-2121-121212121212");

    private static readonly Policy[] _data =
    [
        new Policy
        {
            Id=MasterPolicyId,
            Title = "General School Policy",
            Description = "This policy defines the general operational and behavioral guidelines applicable to all schools unless otherwise specified.",
            sanitizeName = "general-school-policy",
            IsActive = true,
            IsDeleted = false,
            IsDefault = true
        }
    ];

    public Policy[] GetData() => _data;
}
