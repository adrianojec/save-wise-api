using Domain;

namespace Application.Commands.Accounts.Dtos
{
    public class CreateAccountDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public Account ToAccountEntity()
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                UserId = UserId,
                Title = Title,
                DateCreated = DateTime.Now,
            };

            return account;
        }
    }
}