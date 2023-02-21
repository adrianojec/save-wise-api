using Application.Commands.Accounts.Dtos;
using Application.Core;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IUpdateAccountCommand
    {
        Task<Result<bool>> ExecuteCommand(Guid id, UpdateAccountDto input);
    }
}