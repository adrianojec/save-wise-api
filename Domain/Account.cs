using Domain.Enums;

namespace Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = default!;
        public string Title { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool isArchived { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public double Total
        {
            get
            {
                var totalIncome = Transactions.Where(transaction => transaction.TransactionType == TransactionType.Income).Sum(transaction => transaction.Amount);
                var totalExpense = Transactions.Where(transaction => transaction.TransactionType == TransactionType.Expense).Sum(transaction => transaction.Amount);
                return totalIncome - totalExpense;
            }
        }
    }
}