using Domain;
using Domain.Enums;

namespace Application.Commands.Activities.Dtos
{
    public class ActivityDto
    {
        public ActivityDto(Activity item)
        {
            AccountId = item.AccountId;
            TransactionId = item.TransactionId;
            DateCreated = item.DateCreated;
        }
        public Guid AccountId { get; set; }
        public Guid TransactionId { get; set; }
        public ActivityType ActivityType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}