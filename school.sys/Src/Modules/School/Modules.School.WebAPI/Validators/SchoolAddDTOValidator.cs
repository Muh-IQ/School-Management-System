using FluentValidation;
using Modules.School.Domain.DTOs;

namespace Modules.School.WebAPI.Validators;

public class SchoolAddDTOValidator : AbstractValidator<SchoolAddCommand>
{
    public SchoolAddDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("School name is required.")
            .MaximumLength(200).WithMessage("School name must not exceed 200 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(50).WithMessage("Phone must not exceed 50 characters.");

        RuleFor(x => x.LanguageId)
            .NotEmpty().WithMessage("Language is required.");

        RuleFor(x => x.PolicyTitle)
            .MaximumLength(500).WithMessage("Policy title must not exceed 500 characters.")
            .When(x => x.PolicyTitle != null);

        RuleFor(x => x.PolicyDescription)
            .MaximumLength(2000).WithMessage("Policy description must not exceed 2000 characters.")
            .When(x => x.PolicyDescription != null);

    }
}
