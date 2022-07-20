namespace CodeBase.Repositories
{
    using Borders.Models;
    using Microsoft.EntityFrameworkCore;

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
