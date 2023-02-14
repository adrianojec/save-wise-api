using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.UserRepository;

namespace Application.Commands.Accounts
{
    public class GetAccountCommand : IGetAccountCommand
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountCommand(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<AccountWithTransactionsDto> ExecuteCommand(Guid id)
        {
            var account = await _accountRepository.GetById(id);

            if (account == null) throw new NullReferenceException();

            return new AccountWithTransactionsDto(account);
        }
    }
}