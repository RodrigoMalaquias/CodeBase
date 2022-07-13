using CodeBase.Borders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetbyidAsync(Guid id);
        Task AddAsync(UserViewModel user);
    }
}
