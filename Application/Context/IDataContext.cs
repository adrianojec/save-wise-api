using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public interface IDataContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Activity> Activities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}