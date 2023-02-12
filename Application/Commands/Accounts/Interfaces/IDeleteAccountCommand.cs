namespace Application.Commands.Accounts.Interfaces
{
    public interface IDeleteAccountCommand
    {
        Task ExecuteCommand(Guid id);
    }
}