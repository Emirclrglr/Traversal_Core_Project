using Microsoft.EntityFrameworkCore;

namespace SignalR_API.DAL
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
