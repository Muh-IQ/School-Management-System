using Modules.User.Domain.DTOs;
using Modules.User.Domain.Entities; // Add this line to import the User type
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Mappers
{
    public static class UserMappingExtensions
    {
        public static UserDto ToDto(this Domain.Entities.User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                DOB = user.DOB,
                gender = user.Gender,
                IsActive = user.IsActive
            };
        }

        public static Domain.Entities.User ToEntity(this CreateUserDTO request)
        {
            return new Domain.Entities.User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                DOB = request.DOB,
                Gender = request.Gender,
                StartDate = request.StartDate,
                IsActive = true,
                IsDeleted = false,
                CreateAt = DateTime.UtcNow,
                UpdateAt=null,
                
            };
        }

        public static void UpdateEntity(this UpdateUserDTO request, Domain.Entities.User entity)
        {
            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Phone = request.Phone;
            entity.DOB = request.DOB;
            entity.Gender = request.Gender;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.UpdateAt = DateTime.UtcNow;
        }
    }
}
