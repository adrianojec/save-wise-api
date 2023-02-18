using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Domain.Enums;

namespace Application.Commands.Transactions.Dtos
{
    public class CreateTransactionDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; } = 0.0;
        public DateTime Date { get; set; }

        public Transaction ToTransactionEntity()
        {
            var transaction = new Transaction
            {
                Id = Id,
                AccountId = AccountId,
                TransactionType = TransactionType,
                Amount = Amount,
                Date = Date,
            };

            return transaction;
        }

    }
}