using Application.Commands.Transactions.Dtos;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IUpdateTransactionCommand
    {
        Task ExecuteCommand(Guid accountId, Guid id, UpdateTransactionDto item);
    }
}