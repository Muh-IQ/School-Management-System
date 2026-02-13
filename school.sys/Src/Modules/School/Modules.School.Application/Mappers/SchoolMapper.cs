using Modules.School.Domain.DTOs;
using Modules.School.Application.Helpers;

namespace Modules.School.Application.Mappers
{
    public static class SchoolMapper
    {
        private static readonly Domain.Entities.Policy DefaultPolicy = new Domain.Entities.Policy
        {
            Id = Guid.NewGuid(),
            Title = "Master Policy",
            sanitizeName = TextHelper.SlugGenerate("Master Policy"),
            Description = "This policy applies to all schools by default.",
            PolicyType = "Master",
            IsActive = true,
            IsDeleted = false
        };
        private static Domain.Entities.Policy? CreatePolicyIfProvided(SchoolAddDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.PolicyTitle) ||
                string.IsNullOrWhiteSpace(dto.PolicyType))
                return null;

            return new Domain.Entities.Policy
            {
                Id = Guid.NewGuid(),
                Title = dto.PolicyTitle,
                sanitizeName = TextHelper.SlugGenerate(dto.PolicyTitle),
                Description = dto.PolicyDescription ?? "",
                PolicyType = dto.PolicyType,
                IsActive = true,
                IsDeleted = false
            };
        }
        public static Domain.Entities.School MapSchoolAddDTOToEntity(SchoolAddDTO dto, Domain.Entities.Policy? policy = null)
        {
            return new Domain.Entities.School
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                sanitizeName = TextHelper.SlugGenerate(dto.Name),
                Email = dto.Email,
                Phone = dto.Phone,
                LanguageId = dto.LanguageId,
                Policy = CreatePolicyIfProvided(dto) ?? DefaultPolicy,
                IsActive = true,
                IsDeleted = false,
                TimeZone = DateTime.UtcNow.ToString("zzz")
            };
        }

        public static void MapSchoolUpdateDTOToEntity(SchoolUpdateDTO dto, Domain.Entities.School entity)
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
