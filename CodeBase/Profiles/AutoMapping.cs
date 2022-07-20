namespace CodeBase.Profiles
{
    using AutoMapper;
    using Borders.Models;
    using Borders.ViewModel;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
