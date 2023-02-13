using Domain;
using Domain.Enums;

namespace Application.Commands.Transactions.Dtos
{
    public class TransactionDto
    {
        public TransactionDto(Transaction item)
        {
            Id = item.Id;
            AccountId = item.AccountId;
            TransactionType = item.TransactionType;
            Amount = item.Amount;
            DateCreated = item.DateCreated;

        }
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; } = 0.0;
        public DateTime DateCreated { get; set; }
    }
}