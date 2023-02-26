using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.Core;
using Application.Repositories.AccountRepositories;

namespace Application.Commands.Accounts
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountCommand(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Result<bool>> ExecuteCommand(CreateAccountDto input)
        {
            if (string.IsNullOrEmpty(input.Title)) return Result<bool>.Failure("Title is required");

            _accountRepository.Add(input.ToAccountEntity());
            await _accountRepository.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}