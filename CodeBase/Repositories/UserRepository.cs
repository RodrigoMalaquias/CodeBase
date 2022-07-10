using CodeBase.Context;
using CodeBase.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User Getbyid(short id)
        {
            var user = _context.User.Where(i => i.Id == id).FirstOrDefault();
            return user;
        }

    }
}
