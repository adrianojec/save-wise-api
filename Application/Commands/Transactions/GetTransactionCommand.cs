using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Core;
using Application.Repositories.AccountRepositories;
using Application.Repositories.TransactionRepositories;

namespace Application.Commands.Transactions
{
    public class GetTransactionCommand : IGetTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        public GetTransactionCommand
        (
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository
        )
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Result<TransactionDto>> ExecuteCommand(Guid accountId, Guid id)
        {
            var account = await _accountRepository.GetById(accountId);

            if (account == null) return Result<TransactionDto>.Failure("Account not found.");

            var transaction = await _transactionRepository.GetById(id);

            if (transaction == null) return Result<TransactionDto>.Failure("Transaction not found.");

            return Result<TransactionDto>.Success(new TransactionDto(transaction));
        }
    }
}