using API.Controllers.Users.InputModels;
using API.Controllers.Users.ViewModels;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Users
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        public UserController(UserManager<User> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserViewModel>> Login([FromBody] LoginUserInputModel input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null) return Unauthorized();

            var result = await _userManager.CheckPasswordAsync(user, input.Password);

            if (!result) return Unauthorized();

            if (result)
            {
                return new UserViewModel
                {
                    UserName = user.UserName ?? string.Empty,
                    Token = _tokenService.CreateToken(user),
                };
            }

            return Unauthorized();
        }
    }
}