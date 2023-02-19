using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class GetTransactionsCommand : IGetTransactionsCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetTransactionsCommand(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<List<TransactionDto>> ExecuteCommand(Guid accountId)
        {
            var transactions = await _transactionRepository.GetAll();
            var accountTransactions = transactions.Where(transaction => transaction.AccountId == accountId);
            return accountTransactions.Where(account => !account.isArchived).Select(transaction => new TransactionDto(transaction)).ToList();
        }
    }
}