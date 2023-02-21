using Application.Core;

namespace Application.Commands.Accounts.Interfaces
{
    public interface IDeleteAccountCommand
    {
        Task<Result<bool>> ExecuteCommand(Guid id);
    }
}