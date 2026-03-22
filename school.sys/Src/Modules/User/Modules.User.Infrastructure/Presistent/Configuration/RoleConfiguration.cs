using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.User.Domain.Entities;

namespace Modules.User.Infrastructure.Presistent.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            
            builder.ToTable("Roles");

            
            builder.HasKey(x => x.Id);

            
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.CreateAt)
                   .IsRequired();

            builder.Property(x => x.UpdateAt);

           
            builder.HasMany(x => x.UserRoles)
                   .WithOne(x => x.Role)
                   .HasForeignKey(x => x.RoleId);
        }
    }
}