using Application.Commands.Transactions.Dtos;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IGetTransactionCommand
    {
        Task<TransactionDto> ExecuteCommand(Guid accountId, Guid id);
    }
}