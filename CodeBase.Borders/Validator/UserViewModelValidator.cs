namespace CodeBase.Borders.Validator
{
    using CodeBase.Shared;
    using FluentValidation;
    using ViewModel;

    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(Messages.NameIsRequired)
                .MinimumLength(5).WithMessage(Messages.NameMinimumLenght)
                .MaximumLength(30).WithMessage(Messages.NameMaximunLenght);

            RuleFor(x => x.Age)
                .NotNull().WithMessage(Messages.AgeIsRequired)
               .GreaterThan(0).WithMessage(Messages.AgeInvalid);
        }
    }
}
