using Application.Commands.Accounts.Dtos;

namespace API.Controllers.InputModels
{
    public class CreateAccountInputModel
    {
        public string Title { get; set; } = string.Empty;

        public CreateAccountDto ToDto()
        {
            var account = new CreateAccountDto
            {
                Title = Title,
            };

            return account;
        }
    }
}