using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class CreateTransactionCommand : ICreateTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        public CreateTransactionCommand(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task ExecuteCommand(Guid accountId, CreateTransactionDto item)
        {
            var transaction = new CreateTransactionDto
            {
                AccountId = accountId,
                Amount = item.Amount,
                TransactionType = item.TransactionType,
                Date = item.Date,
            };

            _transactionRepository.Add(transaction.ToTransactionEntity());
            await _transactionRepository.SaveChangesAsync();
        }
    }
}