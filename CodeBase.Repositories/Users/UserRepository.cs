namespace CodeBase.Repositories.Users
{
    using AutoMapper;
    using Borders.ViewModel;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = await _context.User.ToListAsync();
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _context.User.FirstOrDefaultAsync(i => i.Id == id);
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
