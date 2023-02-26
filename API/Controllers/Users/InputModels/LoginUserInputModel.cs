using System.ComponentModel.DataAnnotations;

namespace API.Controllers.Users.InputModels
{
    public class LoginUserInputModel
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}