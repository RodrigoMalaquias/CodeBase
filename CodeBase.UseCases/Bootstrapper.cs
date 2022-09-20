namespace CodeBase.UseCases
{
    using Microsoft.Extensions.DependencyInjection;
    using Users.Add;
    using Users.GetAll;
    using Users.GetById;
    using Products.GetAll;
    using CodeBase.UseCases.Products.Add;
    using CodeBase.UseCases.Products.GetById;

    public static class Bootstrapper
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services
                .AddScoped<IAddUserUseCase, AddUserUseCase>()
                .AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>()
                .AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>()
                .AddScoped<IAddProductUseCase, AddProductUseCase>()
                .AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>()
                .AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
        }
    }
}
