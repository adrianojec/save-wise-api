using Domain;
using Domain.Enums;

namespace Application.Commands.Activities.Dtos
{
    public class CreateActivityDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid TransactionId { get; set; }
        public ActivityType ActivityType { get; set; }
        public DateTime DateCreated { get; set; }

        public Activity ToActivityEntity()
        {
            var activity = new Activity
            {
                Id = Id,
                AccountId = AccountId,
                TransactionId = TransactionId,
                ActivityType = ActivityType,
                DateCreated = DateCreated,
            };

            return activity;
        }
    }
}