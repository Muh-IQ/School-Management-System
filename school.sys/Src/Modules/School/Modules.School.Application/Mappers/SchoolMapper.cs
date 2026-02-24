using Modules.School.Domain.DTOs;
using Modules.School.Application.Helpers;
using Modules.School.Domain.Entities.Place;

namespace Modules.School.Application.Mappers
{
    public  class SchoolMapper
    {
        public  Domain.Entities.Policy MapSchoolAddPolicyoEntityPolicy(string PolicyTitle,string PolicyDescription)
        {
            return new Domain.Entities.Policy
            {
                Id = Guid.NewGuid(),
                Title = PolicyTitle,
                sanitizeName = TextHelper.SlugGenerate(PolicyTitle),
                Description = PolicyDescription,
                IsActive = true,
                IsDeleted = false,
                IsDefault = false
            };
        }
        public  Domain.Entities.School MapSchoolAddDTOToEntity(SchoolAddCommand dto, Guid PolicyId )
        {
            return new Domain.Entities.School
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                sanitizeName = TextHelper.SlugGenerate(dto.Name),
                Email = dto.Email,
                Phone = dto.Phone,
                LanguageId = dto.LanguageId,
                PolicyId=PolicyId ,
                IsActive = true,
                IsDeleted = false,
                TimeZone = DateTime.UtcNow.ToString("zzz"),
                
            };
        }

        public  void MapSchoolUpdateDTOToEntity(SchoolUpdateCommand dto, Domain.Entities.School entity)
        {
            entity.Name = dto.Name;
            entity.sanitizeName = TextHelper.SlugGenerate(dto.Name);
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.LanguageId = dto.LanguageId;
            entity.PolicyId = dto.PolicyId;
        }

        
    }
}
