namespace CodeBase.Repositories
{
    using Microsoft.Extensions.DependencyInjection;
    using Users;

    public static class Bootstrapper
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
