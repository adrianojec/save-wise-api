using Application.Commands.Transactions.Dtos;
using Application.Core;

namespace Application.Commands.Transactions.Interfaces
{
    public interface ICreateTransactionCommand
    {
        Task<Result<bool>> ExecuteCommand(Guid accountId, CreateTransactionDto item);
    }
}