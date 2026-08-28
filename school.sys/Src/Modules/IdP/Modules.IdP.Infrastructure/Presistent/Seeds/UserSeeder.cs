using Microsoft.EntityFrameworkCore;
using Modules.IdP.Domain.Entities;

namespace Modules.IdP.Infrastructure.Presistent.Seeds
{
    public class UserSeeder : ISeeder
    {
        private const string DefaultPasswordHash =
            "ABEiM0RVZneImaq7zN3u/w==.I7xMVqa9X0B+zUW1Rf6uQbMU7axSviBdHbM4muPolqg=";

        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.User>().HasData(
                new Domain.Entities.User
                {
                    Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"),
                    Name = "Super Administrator",
                    Email = "superadmin@school.local",
                    Phone = "0000000001",

                    // Precomputed PBKDF2 hash for the default seed password "School@123".
                    // The hash is stored as a constant to keep EF Core seed data deterministic
                    // and to avoid generating a new random salt on every migration.
                    Password = DefaultPasswordHash,

                    DateOfBirth = new DateTime(1990, 1, 1),
                    Gender = true,
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = null,
                    IsDeleted = false,
                    IsActive = true,
                    CreateAt = new DateTime(2026, 1, 1),
                    UpdateAt = null
                },

                new Domain.Entities.User
                {
                    Id = Guid.Parse("a2222222-2222-2222-2222-222222222222"),
                    Name = "School Administrator",
                    Email = "schooladmin@school.local",
                    Phone = "0000000002",
                    Password = DefaultPasswordHash,

                    DateOfBirth = new DateTime(1990, 1, 1),
                    Gender = true,
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = null,
                    IsDeleted = false,
                    IsActive = true,
                    CreateAt = new DateTime(2026, 1, 1),
                    UpdateAt = null
                },

                new Domain.Entities.User
                {
                    Id = Guid.Parse("a3333333-3333-3333-3333-333333333333"),
                    Name = "Teacher",
                    Email = "teacher@school.local",
                    Phone = "0000000003",
                    Password = DefaultPasswordHash,

                    DateOfBirth = new DateTime(1990, 1, 1),
                    Gender = true,
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = null,
                    IsDeleted = false,
                    IsActive = true,
                    CreateAt = new DateTime(2026, 1, 1),
                    UpdateAt = null
                },

                new Domain.Entities.User
                {
                    Id = Guid.Parse("a4444444-4444-4444-4444-444444444444"),
                    Name = "Student",
                    Email = "student@school.local",
                    Phone = "0000000004",
                    Password = DefaultPasswordHash,

                    DateOfBirth = new DateTime(2005, 1, 1),
                    Gender = true,
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = null,
                    IsDeleted = false,
                    IsActive = true,
                    CreateAt = new DateTime(2026, 1, 1),
                    UpdateAt = null
                },

                new Domain.Entities.User
                {
                    Id = Guid.Parse("a5555555-5555-5555-5555-555555555555"),
                    Name = "Parent",
                    Email = "parent@school.local",
                    Phone = "0000000005",
                    Password = DefaultPasswordHash,

                    DateOfBirth = new DateTime(1985, 1, 1),
                    Gender = true,
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = null,
                    IsDeleted = false,
                    IsActive = true,
                    CreateAt = new DateTime(2026, 1, 1),
                    UpdateAt = null
                }
            );
        }
    }
}