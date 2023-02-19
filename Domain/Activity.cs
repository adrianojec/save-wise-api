using Domain.Enums;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; } = default!;
        public ActivityType ActivityType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}