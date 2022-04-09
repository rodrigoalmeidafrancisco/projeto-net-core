using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext() : base()
        {

        }

        public DefaultContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
