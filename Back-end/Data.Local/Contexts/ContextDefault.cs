using Microsoft.EntityFrameworkCore;

namespace Data.Local.Contexts
{
    public class ContextDefault : DbContext
    {
        public ContextDefault()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Account
            //modelBuilder.ApplyConfiguration(new xyzMap());
        }


    }
}
