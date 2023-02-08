namespace Application.Commands.Accounts.Dtos
{
    public class CreateAccountDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}