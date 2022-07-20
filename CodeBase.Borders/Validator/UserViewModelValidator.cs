namespace CodeBase.Borders.Validator
{
    using FluentValidation;
    using ViewModel;

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
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
