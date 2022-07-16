using CodeBase.Borders.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetbyidAsync(Guid id)
        {
            return await _context.User.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


    }
}
