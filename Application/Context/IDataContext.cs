using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public interface IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Save> Savings { get; set; }
        public DbSet<Amount> Amounts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}