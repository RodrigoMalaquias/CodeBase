namespace CodeBase.UseCases
{
    using Users.GetById;
    using Microsoft.Extensions.DependencyInjection;
    using Users.GetAll;

    public static class Bootstrapper
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services
                .AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>()
                .AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
        }
    }
}
