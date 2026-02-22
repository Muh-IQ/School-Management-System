using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(75);

        builder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.CountryId);

        // Seed data: Iraqi cities only (US, UK, Canada, Germany have no cities in seed)
        var iraqId = new Guid("11111111-1111-1111-1111-111111111111");
        var baghdadId = new Guid("a0000001-0000-0000-0000-000000000001");
        var basraId = new Guid("a0000002-0000-0000-0000-000000000002");
        var mosulId = new Guid("a0000003-0000-0000-0000-000000000003");
        var erbilId = new Guid("a0000004-0000-0000-0000-000000000004");
        var kirkukId = new Guid("a0000005-0000-0000-0000-000000000005");

        builder.HasData(
            new City { Id = baghdadId, Name = "Baghdad", CountryId = iraqId, IsDeleted = false, IsActive = true },
            new City { Id = basraId, Name = "Basra", CountryId = iraqId, IsDeleted = false, IsActive = true },
            new City { Id = mosulId, Name = "Mosul", CountryId = iraqId, IsDeleted = false, IsActive = true },
            new City { Id = erbilId, Name = "Erbil", CountryId = iraqId, IsDeleted = false, IsActive = true },
            new City { Id = kirkukId, Name = "Kirkuk", CountryId = iraqId, IsDeleted = false, IsActive = true }
        );
    }
}
