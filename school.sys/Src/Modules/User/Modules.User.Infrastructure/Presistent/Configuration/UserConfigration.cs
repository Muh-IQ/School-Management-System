using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure.Presistent.Configuration
{
    public class UserConfigration : IEntityTypeConfiguration<Domain.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Phone)
                   .HasMaxLength(20);

            builder.Property(x => x.DOB)
                   .IsRequired();

            builder.Property(x => x.Gender)
                   .IsRequired();

            builder.Property(x => x.StartDate)
                   .IsRequired();

            builder.Property(x => x.EndDate);

            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.CreateAt)
                   .IsRequired();

            builder.Property(x => x.UpdateAt);

      
            builder.HasMany(x => x.UserRoles)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
