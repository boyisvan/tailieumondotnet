using Microsoft.EntityFrameworkCore;

namespace hoangducvann_deso1.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context context;
        
        public Context GetAllMember()
        {
            return context.GetAllMember();
        }
        
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        // Define entities here as DbSet<T> properties
        public DbSet<Member> Members { get; set; }
    }
}
