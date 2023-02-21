using Application.Commands.Accounts.Dtos;
using Application.Core;

namespace Application.Commands.Accounts.Interfaces
{
    public interface ICreateAccountCommand
    {
        Task<Result<bool>> ExecuteCommand(CreateAccountDto input);
    }
}