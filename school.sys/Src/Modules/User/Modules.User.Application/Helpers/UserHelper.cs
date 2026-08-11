using Modules.User.Application.Common.DTOs;
using Modules.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Helpers
{
    internal class UserHelper
    {
        public static Domain.Entities.User CreateUser(AddUserDTO dto, Guid userId, string HashedPassword)
        {
            return new Domain.Entities.User
            {
                Id = userId,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                DOB = dto.DateOfBirth,
                Gender = dto.gender,
                Password = HashedPassword,
            };
        }
        public static UserRole CreateUserRole(Guid userId, Guid roleId)
        {
            return new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };
        }
    }
}
