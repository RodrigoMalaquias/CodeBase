namespace CodeBase.Borders
{
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using Validator;
    using ViewModel;

    public static class Bootstrapper
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services
                .AddScoped<IValidator<UserViewModel>, UserViewModelValidator>();
        }
    }
}
