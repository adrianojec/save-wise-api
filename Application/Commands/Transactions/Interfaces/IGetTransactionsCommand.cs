using Application.Commands.Transactions.Dtos;

namespace Application.Commands.Transactions.Interfaces
{
    public interface IGetTransactionsCommand
    {
        Task<List<TransactionDto>> ExecuteCommand();
    }
}