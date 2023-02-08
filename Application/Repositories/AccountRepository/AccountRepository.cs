using Application.Context;
using Application.UserRepository;
using Domain;

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
            _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}