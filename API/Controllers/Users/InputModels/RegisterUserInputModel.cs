namespace API.Controllers.Users.InputModels
{
    public class RegisterUserInputModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwor { get; set; } = string.Empty;
    }
}