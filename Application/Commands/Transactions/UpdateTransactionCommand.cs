using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class UpdateTransactionCommand : IUpdateTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        public UpdateTransactionCommand(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task ExecuteCommand(Guid id, UpdateTransactionDto item)
        {
            var transaction = await _transactionRepository.GetById(id);

            if (transaction == null) throw new NullReferenceException();

            transaction.Amount = item.Amount;
            transaction.TransactionType = item.TransactionType;
            transaction.DateCreated = item.DateCreated;

            await _transactionRepository.SaveChangesAsync();
        }
    }
}