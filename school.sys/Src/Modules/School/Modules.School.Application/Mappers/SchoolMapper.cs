using Modules.School.Domain.DTOs;

namespace Modules.School.Application.Mappers
{
    public  class SchoolMapper
    {
        public  Domain.Entities.Policy MapSchoolAddDTOToEntityPolicy(string PolicyTitle,string PolicyDescription)
        {
            return new Domain.Entities.Policy
            {
                Id = Guid.NewGuid(),
                Title = PolicyTitle,
                Description = PolicyDescription,
                IsActive = true,
                IsDeleted = false,
                IsDefault = false,
                CreateAt=DateTime.Now,
                UpdateAt=DateTime.Now
            };
        }
        public  Domain.Entities.School MapSchoolAddDTOToEntity(SchoolAddCommand dto, Guid policyId )
        {
            return new Domain.Entities.School
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                LanguageId = dto.LanguageId,
                CountryId = dto.CountryId,
                CityId = dto.CityId,
                AreaId = dto.AreaId,
                PolicyId =policyId ,
                IsActive = true,
                IsDeleted = false,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now 
            };
        }

        public  void MapSchoolUpdateDTOToEntity(SchoolUpdateCommand dto, Domain.Entities.School entity)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.LanguageId = dto.LanguageId;
            entity.CountryId = dto.CountryId;
            entity.CityId = dto.CityId;
            entity.AreaId = dto.AreaId;
            entity.PolicyId = dto.PolicyId;
            entity.UpdateAt = DateTime.Now;
        }

        
    }
}
