using CodeBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CodeBase.IoC
{
    public static class Bootstraper
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
