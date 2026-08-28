using Microsoft.EntityFrameworkCore;
using Modules.IdP.Domain.Entities;
using Modules.IdP.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Infrastructure.Presistent.Seeds
{
    public class RoleSeeder : ISeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Code = RoleCodes.SuperAdmin,
                    Name = "Super Administrator"
                },
                new Role
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Code = RoleCodes.SchoolAdmin,
                    Name = "School Administrator"
                },
                new Role
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Code = RoleCodes.Teacher,
                    Name = "Teacher"
                },
                new Role
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Code = RoleCodes.Student,
                    Name = "Student"
                },
                new Role
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Code = RoleCodes.Parent,
                    Name = "Parent"
                }
            );
        }
    }
}
