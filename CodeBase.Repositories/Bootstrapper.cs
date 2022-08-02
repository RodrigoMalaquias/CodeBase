namespace CodeBase.Repositories
{
    using Microsoft.Extensions.DependencyInjection;
    using Products;
    using Users;

    public static class Bootstrapper
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
