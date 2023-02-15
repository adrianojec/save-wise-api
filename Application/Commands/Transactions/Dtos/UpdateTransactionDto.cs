using Domain.Enums;

namespace Application.Commands.Transactions.Dtos
{
    public class UpdateTransactionDto
    {
        public Guid AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; } = 0.0;
        public DateTime DateCreated { get; set; }
    }
}