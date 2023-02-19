using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain
{
    public class Transaction
    {
        // Disallows database to auto-generate an Id
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public TransactionType TransactionType { get; set; }
        public bool isArchived { get; set; }
        public double Amount { get; set; } = 0.0;
        public DateTime Date { get; set; }

    }
}