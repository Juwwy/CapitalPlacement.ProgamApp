

namespace Capital.Program.API.FluentValidations.EmployerProgram
{
    public class EmployerProgramDTOValidator : AbstractValidator<EmployerProgramDTO>
    {
        public EmployerProgramDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.MultipleChoice).NotNull().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.ParagraphQuestion).NotNull().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.NumericQuestion).NotNull().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.DropDownQuestion).NotNull().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.YesNoQuestion).NotNull().WithMessage("{PropertyName} is required!");
            //RuleFor(x => x.DateQuestion).NotNull().WithMessage("{PropertyName} is required!");

        }
    }
}
