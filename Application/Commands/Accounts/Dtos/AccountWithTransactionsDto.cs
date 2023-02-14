using Application.Commands.Transactions.Dtos;
using Domain;

namespace Application.Commands.Accounts.Dtos
{
    public class AccountWithTransactionsDto
    {
        public AccountWithTransactionsDto(Account account)
        {
            Id = account.Id;
            Title = account.Title;
            Transactions = account.Transactions.Select(transaction => new TransactionDto(transaction)).ToList();
            Total = account.Total;
            DateCreated = account.DateCreated;
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<TransactionDto> Transactions { get; set; }
        public double Total { get; set; }
        public DateTime DateCreated { get; set; }
    }
}