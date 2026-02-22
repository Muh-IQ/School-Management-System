using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.School.Domain.Entities.Place;

namespace Modules.School.Infrastructure.Persistent.Configuration;

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("Areas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.CityId);

        // Seed data: areas for Baghdad, Basra, Mosul (Erbil and Kirkuk have no areas)
        var baghdadId = new Guid("a0000001-0000-0000-0000-000000000001");
        var basraId = new Guid("a0000002-0000-0000-0000-000000000002");
        var mosulId = new Guid("a0000003-0000-0000-0000-000000000003");

        builder.HasData(
            new Area { Id = new Guid("b0000001-0000-0000-0000-000000000001"), Name = "Karkh", CityId = baghdadId, IsDeleted = false, IsActive = true },
            new Area { Id = new Guid("b0000002-0000-0000-0000-000000000002"), Name = "Rusafa", CityId = baghdadId, IsDeleted = false, IsActive = true },
            new Area { Id = new Guid("b0000003-0000-0000-0000-000000000003"), Name = "Al-Fao", CityId = basraId, IsDeleted = false, IsActive = true },
            new Area { Id = new Guid("b0000004-0000-0000-0000-000000000004"), Name = "Shatt Al-Arab", CityId = basraId, IsDeleted = false, IsActive = true },
            new Area { Id = new Guid("b0000005-0000-0000-0000-000000000005"), Name = "Old City", CityId = mosulId, IsDeleted = false, IsActive = true },
            new Area { Id = new Guid("b0000006-0000-0000-0000-000000000006"), Name = "Nineveh Plains", CityId = mosulId, IsDeleted = false, IsActive = true }
        );
    }
}
