using API.Controllers.Accounts.InputModels;
using API.Controllers.Accounts.ViewModels;
using API.Controllers.InputModels;
using Application.Commands.Accounts.Interfaces;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Accounts
{
    [ApiController]
    [Route("api/[controller]")]

    public class AccountsController : ControllerBase
    {
        private readonly ICreateAccountCommand _createAccountCommand;
        private readonly IGetAccountsCommand _getAccountsCommand;
        private readonly IGetAccountCommand _getAccountCommand;
        private readonly IUpdateAccountCommand _updateAccountCommand;
        private readonly IDeleteAccountCommand _deleteAccountCommand;
        public AccountsController
        (
            ICreateAccountCommand createAccountCommand,
            IGetAccountsCommand getAccountsCommand,
            IGetAccountCommand getAccountCommand,
            IUpdateAccountCommand updateAccountCommand,
            IDeleteAccountCommand deleteAccountCommand
        )
        {
            _getAccountsCommand = getAccountsCommand;
            _createAccountCommand = createAccountCommand;
            _getAccountCommand = getAccountCommand;
            _updateAccountCommand = updateAccountCommand;
            _deleteAccountCommand = deleteAccountCommand;
        }

        // protected ActionResult HandleResult<T>(Result<T> result)
        // {
        //     if (result.isSuccess && result.Value != null) return Ok(result.Value);
        //     if (result.isSuccess && result.Value == null) return NotFound();
        //     return BadRequest();
        // }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccountInputModel input)
        {
            var result = await _createAccountCommand.ExecuteCommand(input.ToCreateAccountDto());
            if (!result.isSuccess) return BadRequest(result.Error);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _getAccountsCommand.ExecuteCommand();

            if (!accounts.isSuccess) return BadRequest("Error getting accounts");

            var data = accounts.Value.Select(account => new AccountViewModel(account)).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var account = await _getAccountCommand.ExecuteCommand(id);

            if (!account.isSuccess) return BadRequest(account.Error);

            var data = new AccountViewModel(account.Value);

            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAccountInputModel input)
        {
            var account = await _updateAccountCommand.ExecuteCommand(id, input.ToUpdateAccountDto());
            if (!account.isSuccess) return BadRequest(account.Error);
            return Ok(account.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var account = await _deleteAccountCommand.ExecuteCommand(id);
            if (!account.isSuccess) return BadRequest(account.Error);

            return Ok(account.Value);
        }
    }
}