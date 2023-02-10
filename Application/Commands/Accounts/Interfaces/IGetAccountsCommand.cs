using Application.Commands.Accounts.Dtos;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IGetAccountsCommand
    {
        Task<List<AccountDto>> ExecuteCommand();
    }
}