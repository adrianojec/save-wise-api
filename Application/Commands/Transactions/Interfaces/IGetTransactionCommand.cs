using Application.Commands.Transactions.Dtos;
using Application.Core;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IGetTransactionCommand
    {
        Task<Result<TransactionDto>> ExecuteCommand(Guid accountId, Guid id);
    }
}