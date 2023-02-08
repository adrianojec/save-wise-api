using Application.Commands.Accounts.Dtos;

namespace Application.Commands.Accounts.Interfaces
{
    public interface ICreateAccountCommand
    {
        Task ExecuteCommand(CreateAccountDto input);
    }
}