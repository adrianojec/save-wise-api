using Application.Commands.Accounts.Dtos;

namespace API.Controllers.InputModels
{
    public class CreateAccountInputModel
    {
        public string Title { get; set; } = string.Empty;

        public CreateAccountDto ToCreateAccountDto(string userId)
        {
            var account = new CreateAccountDto
            {
                UserId = userId,
                Title = Title,
            };

            return account;
        }
    }
}