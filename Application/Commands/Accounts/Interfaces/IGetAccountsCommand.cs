using Application.Commands.Accounts.Dtos;
using Application.Core;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IGetAccountsCommand
    {
        Task<Result<List<AccountDto>>> ExecuteCommand();
    }
}