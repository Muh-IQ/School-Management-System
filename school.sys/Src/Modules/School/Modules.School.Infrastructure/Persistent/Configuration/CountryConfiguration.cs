using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Seed data: countries (with and without cities)
        var iraqId = new Guid("11111111-1111-1111-1111-111111111111");
        var usId = new Guid("22222222-2222-2222-2222-222222222222");
        var ukId = new Guid("33333333-3333-3333-3333-333333333333");
        var canadaId = new Guid("44444444-4444-4444-4444-444444444444");
        var germanyId = new Guid("55555555-5555-5555-5555-555555555555");

        builder.HasData(
            new Country { Id = iraqId, Name = "Iraq", IsDeleted = false, IsActive = true },
            new Country { Id = usId, Name = "United States", IsDeleted = false, IsActive = true },
            new Country { Id = ukId, Name = "United Kingdom", IsDeleted = false, IsActive = true },
            new Country { Id = canadaId, Name = "Canada", IsDeleted = false, IsActive = true },
            new Country { Id = germanyId, Name = "Germany", IsDeleted = false, IsActive = true }
        );
    }
}
