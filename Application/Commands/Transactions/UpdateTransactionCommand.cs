using Application.Commands.Activities.Dtos;
using Application.Commands.Transactions.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Repositories.ActivityRepository;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class UpdateTransactionCommand : IUpdateTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IActivityRepository _activityRepository;
        public UpdateTransactionCommand(
            ITransactionRepository transactionRepository,
            IActivityRepository activityRepository
            )
        {
            _transactionRepository = transactionRepository;
            _activityRepository = activityRepository;
        }
        public async Task ExecuteCommand(Guid id, UpdateTransactionDto item)
        {
            var transaction = await _transactionRepository.GetById(id);

            if (transaction == null) throw new NullReferenceException();

            transaction.Amount = item.Amount;
            transaction.TransactionType = item.TransactionType;
            transaction.Date = item.Date;

            var activity = new CreateActivityDto
            {
                AccountId = transaction.AccountId,
                TransactionId = transaction.Id,
                DateCreated = DateTime.Now,
            };

            _activityRepository.Add(activity.ToActivityEntity());
            await _transactionRepository.SaveChangesAsync();
        }
    }
}