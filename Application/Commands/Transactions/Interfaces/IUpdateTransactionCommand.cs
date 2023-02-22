using Application.Commands.Transactions.Dtos;
using Application.Core;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IUpdateTransactionCommand
    {
        Task<Result<bool>> ExecuteCommand(Guid accountId, Guid id, UpdateTransactionDto input);
    }
}