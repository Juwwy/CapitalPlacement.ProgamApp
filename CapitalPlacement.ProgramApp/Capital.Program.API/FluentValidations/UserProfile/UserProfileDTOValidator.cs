using Capital.Program.Application.DTOs;
using FluentValidation;

namespace Capital.Program.API.FluentValidations.UserProfile
{
    public class UserProfileDTOValidator : AbstractValidator<UserProfileDTO>
    {
        public UserProfileDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.EmailAddress).EmailAddress().NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.CurrentResidence).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Nationality).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.DateOfBirth).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Gender).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
        }
    }
}
