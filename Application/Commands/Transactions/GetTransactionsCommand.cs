using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Core;
using Application.Repositories.TransactionRepository;
using Application.UserRepository;

namespace Application.Commands.Transactions
{
    public class GetTransactionsCommand : IGetTransactionsCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        public GetTransactionsCommand
        (
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository
        )
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Result<List<TransactionDto>>> ExecuteCommand(Guid accountId)
        {
            var account = await _accountRepository.GetById(accountId);

            if (account == null) return Result<List<TransactionDto>>.Failure("Account not found.");

            var transactions = await _transactionRepository.GetAll();

            var accountTransactions = transactions.Where(transaction => transaction.AccountId == accountId);

            var activeTransactions = accountTransactions.Where(account => !account.isArchived).Select(transaction => new TransactionDto(transaction)).ToList();

            return Result<List<TransactionDto>>.Success(activeTransactions);
        }
    }
}