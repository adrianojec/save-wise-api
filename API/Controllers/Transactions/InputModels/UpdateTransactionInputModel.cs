using Application.Commands.Transactions.Dtos;
using Domain.Enums;

namespace API.Controllers.Transactions.InputModels
{
    public class UpdateTransactionInputModel
    {
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }

        public UpdateTransactionDto ToUpdateTransactionDto()
        {
            var transaction = new UpdateTransactionDto
            {
                TransactionType = TransactionType,
                Amount = Amount,
            };

            return transaction;
        }
    }
}