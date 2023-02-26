using API.Controllers.Users.InputModels;
using API.Controllers.Users.ViewModels;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost("register")]
        public async Task<ActionResult<UserViewModel>> Register(RegisterUserInputModel input)
        {
            if (await _userManager.Users.AnyAsync(user => user.UserName == input.UserName))
            {
                return BadRequest("Username is already taken");
            }

            if (await _userManager.Users.AnyAsync(user => user.Email == input.Email))
            {
                return BadRequest("Email is already taken");
            }

            var user = new User
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName,
                Email = input.Email,
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                return new UserViewModel
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }

            return BadRequest(result.Errors);
        }
    }
}