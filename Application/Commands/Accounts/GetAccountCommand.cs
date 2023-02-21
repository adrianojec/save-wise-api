using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.Core;
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

        public async Task<Result<AccountDto>> ExecuteCommand(Guid id)
        {
            var account = await _accountRepository.GetById(id);

            if (account == null) return Result<AccountDto>.Failure("Account not found.");

            var data = new AccountDto(account);

            return Result<AccountDto>.Success(data);
        }
    }
}