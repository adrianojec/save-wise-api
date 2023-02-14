using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class GetTransactionCommand : IGetTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetTransactionCommand(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionDto> ExecuteCommand(Guid accountId, Guid id)
        {
            var transaction = await _transactionRepository.GetById(id);

            if (transaction == null) throw new NullReferenceException();

            if (transaction.AccountId != accountId) throw new NotImplementedException();

            return new TransactionDto(transaction);
        }
    }
}