using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.Core;
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
        public async Task<Result<bool>> ExecuteCommand(Guid id, UpdateAccountDto input)
        {
            if (string.IsNullOrEmpty(input.Title)) return Result<bool>.Failure("Title is required");

            var account = await _accountRepository.GetById(id);

            if (account == null) return Result<bool>.Failure("Account not found");

            account.Title = input.Title;

            await _accountRepository.SaveChangesAsync();

            return Result<bool>.Success(true);

        }
    }
}