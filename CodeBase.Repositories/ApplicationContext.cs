using CodeBase.Borders.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBase.Repositories
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
