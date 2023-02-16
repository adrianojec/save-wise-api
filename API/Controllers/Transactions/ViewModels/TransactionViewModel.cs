using Application.Commands.Transactions.Dtos;
using Domain.Enums;

namespace API.Controllers.Transactions.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionViewModel(TransactionDto item)
        {
            Id = item.Id;
            TransactionType = item.TransactionType;
            Amount = item.Amount;
            Date = item.Date;
        }
        public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; } = 0.0;
        public DateTime Date { get; set; }
    }
}