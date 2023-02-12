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

        public async Task<AccountDto> ExecuteCommand(Guid id)
        {
            var account = await _accountRepository.GetById(id);
            return new AccountDto(account);
        }
    }
}