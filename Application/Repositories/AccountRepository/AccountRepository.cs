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
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetById(Guid id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);

            if (account == null) throw new NotImplementedException();

            return account;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}