using AutoMapper;
using CodeBase.Borders;
using CodeBase.Borders.Model;

namespace CodeBase.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserViewModel>();
        } 
    }
}
