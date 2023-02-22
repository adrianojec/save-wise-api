using Application.Commands.Activities.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Core;
using Application.Repositories.ActivityRepository;
using Application.Repositories.TransactionRepository;
using Application.UserRepository;
using Domain.Enums;

namespace Application.Commands.Transactions
{
    public class DeleteTransactionCommand : IDeleteTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IAccountRepository _accountRepository;
        public DeleteTransactionCommand
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
        public async Task<Result<bool>> ExecuteCommand(Guid accountId, Guid id)
        {

            var account = await _accountRepository.GetById(accountId);

            if (account == null) return Result<bool>.Failure("Account not found.");

            var transaction = await _transactionRepository.GetById(id);

            if (transaction == null) return Result<bool>.Failure("Transaction not found.");

            var activity = new CreateActivityDto
            {
                AccountId = transaction.AccountId,
                TransactionId = id,
                ActivityType = ActivityType.Delete,
                DateCreated = DateTime.Now,
            };

            _activityRepository.Add(activity.ToActivityEntity());

            await _transactionRepository.Delete(id);
            await _transactionRepository.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}