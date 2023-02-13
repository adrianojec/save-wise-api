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
        public async Task<List<TransactionDto>> ExecuteCommand()
        {
            var transactions = await _transactionRepository.GetAll();
            return transactions.Select(transaction => new TransactionDto(transaction)).ToList();
        }
    }
}