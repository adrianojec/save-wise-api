using API.Controllers.Accounts.InputModels;
using API.Controllers.Accounts.ViewModels;
using API.Controllers.InputModels;
using Application.Commands.Accounts.Interfaces;
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

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAccountInputModel input)
        {
            await _createAccountCommand.ExecuteCommand(input.ToCreateAccountDto());
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountViewModel>>> GetAll()
        {
            var accounts = await _getAccountsCommand.ExecuteCommand();
            return accounts.Select(account => new AccountViewModel(account)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<AccountViewModel> GetById([FromRoute] Guid id)
        {
            var account = await _getAccountCommand.ExecuteCommand(id);
            return new AccountViewModel(account);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAccountInputModel input)
        {
            await _updateAccountCommand.ExecuteCommand(id, input.ToUpdateAccountDto());
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _deleteAccountCommand.ExecuteCommand(id);
            return Ok();
        }
    }
}