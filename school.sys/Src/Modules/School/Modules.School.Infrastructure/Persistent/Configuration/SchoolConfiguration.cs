using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Infrastructure.Persistent.Configuration
{
    public class SchoolConfiguration : IEntityTypeConfiguration<Domain.Entities.School>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.School> builder)
        {
            builder.ToTable("Schools");

            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Language)
                .WithMany()
                .HasForeignKey(s => s.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Policy)
                .WithMany()
                .HasForeignKey(s => s.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
