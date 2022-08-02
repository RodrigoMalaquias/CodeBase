namespace CodeBase.Profiles
{
    using AutoMapper;
    using Borders.Models;
    using Borders.ViewModel;
    using System.Collections.Generic;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<IEnumerable<ProductViewModel>, IEnumerable<Product>>();
        }
    }
}
