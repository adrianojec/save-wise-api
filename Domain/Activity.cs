namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; } = default!;
        public DateTime DateCreated { get; set; }
    }
}