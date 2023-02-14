using Application.Commands.Accounts.Dtos;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IGetAccountCommand
    {
        Task<AccountWithTransactionsDto> ExecuteCommand(Guid id);
    }
}