using API.Controllers.InputModels;
using Application.Commands.Accounts.Dtos;
using Application.Commands.Accounts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Accounts
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountsController : ControllerBase
    {
        private readonly ICreateAccountCommand _createAccountCommand;
        public AccountsController(ICreateAccountCommand createAccountCommand)
        {
            _createAccountCommand = createAccountCommand;

        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccountInputModel input)
        {
            await _createAccountCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }
    }
}