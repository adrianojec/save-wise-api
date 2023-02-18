using Application.Commands.Accounts.Dtos;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IGetAccountCommand
    {
        Task<AccountDto> ExecuteCommand(Guid id);
    }
}