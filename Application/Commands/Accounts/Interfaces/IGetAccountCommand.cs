using Application.Commands.Accounts.Dtos;
using Application.Core;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IGetAccountCommand
    {
        Task<Result<AccountDto>> ExecuteCommand(string userId, Guid id);
    }
}