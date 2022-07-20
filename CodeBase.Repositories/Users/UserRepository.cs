namespace CodeBase.Repositories.Users
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Borders.Models;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(user, cancellationToken: cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken: cancellationToken) > 0;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.User.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.User.Where(i => i.Id == id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}