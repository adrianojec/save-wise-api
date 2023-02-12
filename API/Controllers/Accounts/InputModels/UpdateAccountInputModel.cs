using Application.Commands.Accounts.Dtos;

namespace API.Controllers.Accounts.InputModels
{
    public class UpdateAccountInputModel
    {
        public string Title { get; set; } = string.Empty;

        public UpdateAccountDto ToDto()
        {
            var account = new UpdateAccountDto
            {
                Title = Title
            };

            return account;
        }
    }
}