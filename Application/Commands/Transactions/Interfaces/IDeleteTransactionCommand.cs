using Application.Core;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IDeleteTransactionCommand
    {
        Task<Result<bool>> ExecuteCommand(Guid accountId, Guid id);
    }
}