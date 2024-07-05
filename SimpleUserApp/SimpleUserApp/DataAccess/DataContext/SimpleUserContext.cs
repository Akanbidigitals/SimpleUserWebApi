using Microsoft.EntityFrameworkCore;
using SimpleUserApp.Models;

namespace SimpleUserApp.DataAccess.DataContext
{
    public class SimpleUserContext : DbContext
    {
        public SimpleUserContext(DbContextOptions options):base(options) { }

        public DbSet<SimpleUser>Users { get; set; }
    }
}
