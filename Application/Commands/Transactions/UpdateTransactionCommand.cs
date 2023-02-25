using Application.Commands.Activities.Dtos;
using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Core;
using Application.Repositories.AccountRepositories;
using Application.Repositories.ActivityRepositories;
using Application.Repositories.TransactionRepositories;
using Domain.Enums;

namespace Application.Commands.Transactions
{
    public class UpdateTransactionCommand : IUpdateTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IAccountRepository _accountRepository;
        public UpdateTransactionCommand
        (
            ITransactionRepository transactionRepository,
            IActivityRepository activityRepository,
            IAccountRepository accountRepository
        )
        {
            _transactionRepository = transactionRepository;
            _activityRepository = activityRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Result<bool>> ExecuteCommand(Guid accountId, Guid id, UpdateTransactionDto input)
        {
            var account = await _accountRepository.GetById(accountId);

            if (account == null) return Result<bool>.Failure("Account not found.");

            var transaction = await _transactionRepository.GetById(id);

            if (transaction == null) return Result<bool>.Failure("Transaction not found.");

            if (input.Amount <= 0) return Result<bool>.Failure("Amount must be greater than zero");

            transaction.Amount = input.Amount;
            transaction.TransactionType = input.TransactionType;
            transaction.Date = input.Date;

            var activity = new CreateActivityDto
            {
                AccountId = transaction.AccountId,
                TransactionId = transaction.Id,
                ActivityType = ActivityType.Update,
                DateCreated = DateTime.Now,
            };

            _activityRepository.Add(activity.ToActivityEntity());
            await _transactionRepository.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}