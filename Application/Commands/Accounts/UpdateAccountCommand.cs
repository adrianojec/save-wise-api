using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.UserRepository;

namespace Application.Commands.Accounts
{
    public class UpdateAccountCommand : IUpdateAccountCommand
    {
        private readonly IAccountRepository _accountRepository;
        public UpdateAccountCommand(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public async Task ExecuteCommand(Guid id, UpdateAccountDto item)
        {
            var account = await _accountRepository.GetById(id);

            if (account == null) throw new NullReferenceException();

            account.Title = item.Title;

            await _accountRepository.SaveChangesAsync();

        }
    }
}