using FluentValidation;
using Modules.IdP.Application.Common.DTOs;

namespace Modules.IdP.WebAPI.Validators.Users
{
    public class AddUserDTOValidator : AbstractValidator<AddUserDTO> {
        public AddUserDTOValidator() {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Email must be a valid email address.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
            RuleFor(x => x.SchoolID).NotEmpty().WithMessage("School ID is required."); 
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.").LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");
        } 
    }
}
