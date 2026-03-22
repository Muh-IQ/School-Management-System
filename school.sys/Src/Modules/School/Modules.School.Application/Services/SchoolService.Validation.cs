using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.DTOs;

namespace Modules.School.Application.Services
{
    public partial class SchoolService
    {
        private Result ValidatePolicyInfo(string policyTitle, string policyDescription)
        {
            bool hasTitle = !string.IsNullOrWhiteSpace(policyTitle);
            bool hasDescription = !string.IsNullOrWhiteSpace(policyDescription);

            if (hasTitle != hasDescription)
            {
                return Result.Failure(ErrorType.BadRequest,"Both PolicyTitle and PolicyDescription should be provided together.");
            }

            return Result.Success();
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _SchoolRepository.AnyAsync(s => s.Email == email);
        }

        private async Task<bool> PhoneExists(string phone)
        {
            return await _SchoolRepository.AnyAsync(s => s.Phone == phone);
        }

        private async Task<Result> ValidateContactUniquenessAsync(string email, string phone)
        {
            if (await EmailExists(email))
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage(ExistsEmail: email));

            if (await PhoneExists(phone))
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage(ExistsPhone: phone));

            return Result.Success();
        }

        private async Task<bool> LanguageExists(Guid id)
        {
            return await _LanguageRepository.AnyAsync(l => l.Id == id);
        }
        private async Task<Result> CheckLocation(Guid countryId, Guid cityId, Guid areaId)
        {
            if (!await _CountryRepository.AnyAsync(c => c.Id == countryId))
                return Result.Failure(ErrorType.NotFound, CountryErrors.NotFoundMessage(countryId));

            if (!await _CityRepository.AnyAsync(c => c.CountryId == countryId && c.Id == cityId))
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(cityId));

            if (!await _AreaRepository.AnyAsync(a => a.CityId == cityId && a.Id == areaId))
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(areaId));

            return Result.Success();
        }

        private bool IsSchoolDataUnchanged(SchoolUpdateCommand schoolUpdateCommand,Domain.Entities.School school)
        {
            return
                school.Email == schoolUpdateCommand.Email &&
                school.Phone == schoolUpdateCommand.Phone &&
                school.Name == schoolUpdateCommand.Name &&
                school.LanguageId == schoolUpdateCommand.LanguageId &&
                school.CountryId == schoolUpdateCommand.CountryId &&
                school.CityId == schoolUpdateCommand.CityId &&
                school.AreaId == schoolUpdateCommand.AreaId;
        }

        private bool IsPolicyDataUnchanged(SchoolUpdateCommand schoolUpdateCommand,Domain.Entities.Policy policy)
        {
            return
                policy.Title == schoolUpdateCommand.PolicyTitle &&
                policy.Description == schoolUpdateCommand.PolicyDescription;
        }
    }
}
