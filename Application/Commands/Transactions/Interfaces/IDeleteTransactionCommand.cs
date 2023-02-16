namespace Application.Commands.Transactions.Interfaces
{
    public interface IDeleteTransactionCommand
    {
        Task ExecuteCommand(Guid id);
    }
}