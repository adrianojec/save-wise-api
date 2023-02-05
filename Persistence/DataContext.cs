using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Save> Savings { get; set; } = default!;
        public DbSet<Amount> Amounts { get; set; } = default!;
    }
}