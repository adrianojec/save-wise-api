using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Application.UserRepository;
using Domain;

namespace Application.Commands.Accounts
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountCommand(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }
        public async Task ExecuteCommand(CreateAccountDto input)
        {
            var account = new Account
            {
                Id = input.Id,
                Title = input.Title,
            };

            _accountRepository.Add(account);
            await _accountRepository.SaveChangesAsync();
        }
    }
}