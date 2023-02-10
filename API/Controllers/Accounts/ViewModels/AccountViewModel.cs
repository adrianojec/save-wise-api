using Application.Commands.Accounts.Dtos;

namespace API.Controllers.Accounts.ViewModels
{
    public class AccountViewModel
    {
        public AccountViewModel(AccountDto account)
        {
            Id = account.Id;
            Title = account.Title;
            Total = account.Total;
            DateCreated = account.DateCreated;
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Total { get; set; }
        public DateTime DateCreated { get; set; }
    }
}