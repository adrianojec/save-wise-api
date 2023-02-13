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
            _accountRepository.Add(input.ToAccountEntity());

            await _accountRepository.SaveChangesAsync();
        }
    }
}