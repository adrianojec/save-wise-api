using Application.Commands.Accounts.Interfaces;
using Application.UserRepository;

namespace Application.Commands.Accounts
{
    public class DeleteAccountCommand : IDeleteAccountCommand
    {
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountCommand(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public async Task ExecuteCommand(Guid id)
        {
            await _accountRepository.Delete(id);
            await _accountRepository.SaveChangesAsync();
        }
    }
}