using Microsoft.EntityFrameworkCore;
using Specification.Models;

namespace Specification.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books{ get; set; }
    }
}
