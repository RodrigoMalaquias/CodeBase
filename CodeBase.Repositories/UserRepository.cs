using AutoMapper;
using CodeBase.Borders;
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
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(UserViewModel user)
        {
            var entity = _mapper.Map<User>(user);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = await _context.User.ToListAsync();
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetbyidAsync(Guid id)
        {
            var user = await _context.User.Where(i => i.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserViewModel>(user);
        }

       
    }
}
