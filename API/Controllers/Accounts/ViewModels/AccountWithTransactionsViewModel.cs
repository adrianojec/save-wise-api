using API.Controllers.Transactions.ViewModels;
using Application.Commands.Accounts.Dtos;

namespace API.Controllers.Accounts.ViewModels
{
    public class AccountWithTransactionsViewModel
    {
        public AccountWithTransactionsViewModel(AccountWithTransactionsDto item)
        {
            Id = item.Id;
            Title = item.Title;
            Transactions = item.Transactions.Select(transaction => new TransactionViewModel(transaction)).ToList();
            Total = item.Total;
            DateCreated = item.DateCreated;
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TransactionViewModel> Transactions { get; set; }
        public double Total { get; set; }
        public DateTime DateCreated { get; set; }
    }
}