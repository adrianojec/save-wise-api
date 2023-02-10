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
        public AccountsController
        (
            ICreateAccountCommand createAccountCommand,
            IGetAccountsCommand getAccountsCommand
        )
        {
            _getAccountsCommand = getAccountsCommand;
            _createAccountCommand = createAccountCommand;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccountInputModel input)
        {
            await _createAccountCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }

        [HttpGet]
        public async Task<List<AccountViewModel>> GetAll()
        {
            var accounts = await _getAccountsCommand.ExecuteCommand();
            return accounts.Select(account => new AccountViewModel(account)).ToList();
        }
    }
}