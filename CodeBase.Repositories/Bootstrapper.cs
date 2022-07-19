namespace CodeBase.Repositories
{
    using Users;
    using Microsoft.Extensions.DependencyInjection;

    public static class Bootstrapper
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IUserRepository, UserRepository>();
        }
    }
}
