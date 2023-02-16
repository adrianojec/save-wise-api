using Application.Commands.Transactions.Interfaces;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class DeleteTransactionCommand : IDeleteTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        public DeleteTransactionCommand(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;

        }
        public async Task ExecuteCommand(Guid id)
        {
            await _transactionRepository.Delete(id);
            await _transactionRepository.SaveChangesAsync();
        }
    }
}