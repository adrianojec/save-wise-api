using Application.Context;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDataContext _context;
        public TransactionRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetById(Guid id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == id);

            if (transaction == null) throw new NullReferenceException();

            return transaction;
        }

        public void Add(Transaction item)
        {
            _context.Transactions.Add(item);
        }

        public async Task Delete(Guid id)
        {
            var transaction = await GetById(id);
            _context.Transactions.Remove(transaction);
        }

        public async Task Update(Transaction item)
        {
            var transaction = await GetById(item.Id);

            if (transaction == null) throw new NullReferenceException();

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}