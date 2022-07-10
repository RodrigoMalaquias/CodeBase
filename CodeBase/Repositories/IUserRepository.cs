using CodeBase.Model;
using System.Collections.Generic;

namespace CodeBase.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
