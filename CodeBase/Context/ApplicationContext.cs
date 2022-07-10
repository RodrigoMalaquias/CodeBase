using CodeBase.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBase.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public virtual DbSet<User> User
        {
            get;
            set;
        }
    }
}
