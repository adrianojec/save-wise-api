using Application.Commands.Transactions.Dtos;

namespace Application.Commands.Transactions.Interfaces
{
    public interface ICreateTransactionCommand
    {
        Task ExecuteCommand(Guid accountId, CreateTransactionDto item);
    }
}