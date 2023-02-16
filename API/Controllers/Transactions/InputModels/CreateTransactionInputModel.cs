using Application.Commands.Transactions.Dtos;
using Domain;
using Domain.Enums;

namespace API.Controllers.Transactions.InputModels
{
    public class CreateTransactionInputModel
    {
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public CreateTransactionDto ToCreateTransactionDto()
        {
            var transaction = new CreateTransactionDto
            {
                TransactionType = TransactionType,
                Amount = Amount,
                Date = Date,
            };

            return transaction;
        }
    }
}