using Application.Commands.Transactions.Dtos;
using Application.Core;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IGetTransactionsCommand
    {
        Task<Result<List<TransactionDto>>> ExecuteCommand(Guid accountId);
    }
}