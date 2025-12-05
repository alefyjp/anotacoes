using Microsoft.EntityFrameworkCore;
using GNOC.Models;

namespace GNOC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        public DbSet<GNOC.Models.Task> Tasks { get; set; }
    }
}
