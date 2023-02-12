using Application.Commands.Accounts.Dtos;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IUpdateAccountCommand
    {
        Task ExecuteCommand(Guid id, UpdateAccountDto item);
    }
}