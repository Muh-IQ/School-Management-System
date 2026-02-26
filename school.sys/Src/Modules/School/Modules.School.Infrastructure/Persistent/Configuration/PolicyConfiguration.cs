using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.School.Domain.Entities;
using Modules.School.Infrastructure.Persistent.seed;

namespace Modules.School.Infrastructure.Persistent.Configuration
{
    public class PolicyConfiguration: IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policies");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            //builder.HasData(DefaultData.DefaultPolicy);
        }
    }
}
