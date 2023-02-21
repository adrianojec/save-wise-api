using Application.Context;
using Application.UserRepository;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDataContext _context;
        public AccountRepository(IDataContext context)
        {
            _context = context;
        }

        public void Add(Account item)
        {
            _context.Accounts.Add(item);
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Accounts.Include(account => account.Transactions).ToListAsync();
        }

        public async Task<Account> GetById(Guid id)
        {
            var account = await _context.Accounts.Include(account => account.Transactions).FirstOrDefaultAsync(account => account.Id == id && !account.isArchived);
            return account;
        }

        public async Task Update(Account item)
        {
            var account = await GetById(item.Id);

            account.Title = item.Title;
        }
        public async Task Delete(Guid id)
        {
            var account = await GetById(id);

            account.isArchived = true;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}