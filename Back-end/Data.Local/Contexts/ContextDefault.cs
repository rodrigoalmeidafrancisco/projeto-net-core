using Microsoft.EntityFrameworkCore;

namespace Data.Local.Contexts
{
    public class ContextDefault : DbContext
    {
        public ContextDefault(DbContextOptions<ContextDefault> options) : base(options) { }

        //public DbSet<XYZ> Xyz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new XyzMap());
        }

    }
}
