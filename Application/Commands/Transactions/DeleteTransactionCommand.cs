using Application.Commands.Activities.Dtos;
using Application.Commands.Transactions.Interfaces;
using Application.Repositories.ActivityRepository;
using Application.Repositories.TransactionRepository;

namespace Application.Commands.Transactions
{
    public class DeleteTransactionCommand : IDeleteTransactionCommand
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IActivityRepository _activityRepository;
        public DeleteTransactionCommand(
            ITransactionRepository transactionRepository,
            IActivityRepository activityRepository
            )
        {
            _transactionRepository = transactionRepository;
            _activityRepository = activityRepository;
        }
        public async Task ExecuteCommand(Guid id)
        {
            var transaction = await _transactionRepository.GetById(id);

            var activity = new CreateActivityDto
            {
                AccountId = transaction.AccountId,
                TransactionId = id,
                DateCreated = DateTime.Now,
            };

            _activityRepository.Add(activity.ToActivityEntity());

            await _transactionRepository.Delete(id);
            await _transactionRepository.SaveChangesAsync();
        }
    }
}