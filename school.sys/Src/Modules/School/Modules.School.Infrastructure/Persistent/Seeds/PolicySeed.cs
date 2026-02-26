using Modules.School.Domain.Entities;

namespace Modules.School.Infrastructure.Persistent.Seeds;

public class PolicySeed : IEntitySeed<Policy>
{
    public static readonly Guid MasterPolicyId = new("12112121-2121-2121-2121-121212121212");

    private static readonly Policy[] _data =
    [
        new Policy
        {
            Id = MasterPolicyId,
            Title = "Master Policy",
            sanitizeName = "master-policy",
            Description = "This policy applies to all schools by default.",
            IsActive = true,
            IsDeleted = false,
            IsDefault = true
        }
    ];

    public Policy[] GetData() => _data;
}
