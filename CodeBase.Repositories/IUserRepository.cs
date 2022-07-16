using CodeBase.Borders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetbyidAsync(Guid id);
        Task AddAsync(User user);
    }
}
