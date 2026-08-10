using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Validators.Users
{
    using FluentValidation;
    using Modules.User.Domain.DTOs;

    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            // Name
                RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Please provide a valid email address.")
                .MaximumLength(255)
                .WithMessage("Email cannot exceed 255 characters.");

            // Phone
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .MaximumLength(20)
                .WithMessage("Phone number cannot exceed 20 characters.");

            // Date of Birth
            RuleFor(x => x.DOB)
                .NotEmpty()
                .WithMessage("Date of birth is required.")
                .LessThan(DateTime.UtcNow)
                .WithMessage("Date of birth must be in the past.");

            // Gender
            RuleFor(x => x.Gender)
                .Must(gender => gender == 0 || gender == 1)
                .WithMessage("Gender must be either 0 (Male) or 1 (Female).");

            // Start Date
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("Start date is required.");

            // End Date
            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("End date must be after the start date.");
        }
     }

}


