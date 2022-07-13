using CodeBase.Borders.Model;
using FluentValidation;

namespace CodeBase.Borders.Validator
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Name is required")
                .MinimumLength(5).WithMessage("Minimum length must be 5 characters")
                .MaximumLength(30).WithMessage("Maximum length must be 5 characters");

            RuleFor(x => x.Age)
                .NotNull().WithMessage("Age is required")
               .GreaterThan(0).WithMessage("Age invalid");
        }
    }
}
