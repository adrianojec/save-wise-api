using Application.Commands.Transactions.Dtos;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IUpdateTransactionCommand
    {
        Task ExecuteCommand(Guid id, UpdateTransactionDto item);
    }
}