using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.Core;
using Application.Repositories.AccountRepositories;

namespace Application.Commands.Accounts
{
    public class GetAccountCommand : IGetAccountCommand
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountCommand(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result<AccountDto>> ExecuteCommand(string userId, Guid id)
        {
            var account = await _accountRepository.GetById(id);

            if (userId != account.UserId) return Result<AccountDto>.Failure("Not existing account for this user");

            if (account == null) return Result<AccountDto>.Failure("Account not found.");

            var data = new AccountDto(account);

            return Result<AccountDto>.Success(data);
        }
    }
}