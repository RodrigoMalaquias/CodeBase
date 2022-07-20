namespace CodeBase.UseCases
{
    using Microsoft.Extensions.DependencyInjection;
    using Users.Add;
    using Users.GetAll;
    using Users.GetById;

    public static class Bootstrapper
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services
                .AddScoped<IAddUserUseCase, AddUserUseCase>()
                .AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>()
                .AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
        }
    }
}
