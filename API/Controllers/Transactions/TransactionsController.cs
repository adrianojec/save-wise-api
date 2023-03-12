using API.Controllers.Transactions.InputModels;
using API.Controllers.Transactions.ViewModels;
using Application.Commands.Transactions.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Transactions
{
   [ApiController]
   [Route("api/accounts/{accountId}/[controller]")]
   public class TransactionsController : ControllerBase
   {
      private readonly ICreateTransactionCommand _createTransactionCommand;
      private readonly IGetTransactionsCommand _getTransactionsCommand;
      private readonly IGetTransactionCommand _getTransactionCommand;
      private readonly IUpdateTransactionCommand _updateTransactionCommand;
      private readonly IDeleteTransactionCommand _deleteTransactionCommand;
      public TransactionsController(
          ICreateTransactionCommand createTransactionCommand,
          IGetTransactionsCommand getTransactionsCommand,
          IGetTransactionCommand getTransactionCommand,
          IUpdateTransactionCommand updateTransactionCommand,
          IDeleteTransactionCommand deleteTransactionCommand
          )
      {
         _createTransactionCommand = createTransactionCommand;
         _getTransactionsCommand = getTransactionsCommand;
         _getTransactionCommand = getTransactionCommand;
         _updateTransactionCommand = updateTransactionCommand;
         _deleteTransactionCommand = deleteTransactionCommand;
      }

      [AllowAnonymous]
      [HttpPost]
      public async Task<IActionResult> Create([FromRoute] Guid accountId, [FromBody] CreateTransactionInputModel input)
      {
         var result = await _createTransactionCommand.ExecuteCommand(accountId, input.ToCreateTransactionDto());

         if (!result.isSuccess) return BadRequest(result.Error);

         return Ok(result.Value);
      }

      [HttpGet]
      public async Task<ActionResult<List<TransactionViewModel>>> GetAll([FromRoute] Guid accountId)
      {
         var result = await _getTransactionsCommand.ExecuteCommand(accountId);

         if (!result.isSuccess) return BadRequest(result.Error);

         var transactions = result.Value.Select(transaction => new TransactionViewModel(transaction)).ToList();

         return Ok(transactions);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<TransactionViewModel>> Get([FromRoute] Guid accountId, [FromRoute] Guid id)
      {
         var result = await _getTransactionCommand.ExecuteCommand(accountId, id);

         if (!result.isSuccess) return BadRequest(result.Error);

         return Ok(new TransactionViewModel(result.Value));
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Update([FromRoute] Guid accountId, [FromRoute] Guid id, [FromBody] UpdateTransactionInputModel input)
      {
         var result = await _updateTransactionCommand.ExecuteCommand(accountId, id, input.ToUpdateTransactionDto());

         if (!result.isSuccess) return BadRequest(result.Error);

         return Ok(result.Value);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete([FromRoute] Guid accountId, [FromRoute] Guid id)
      {
         var result = await _deleteTransactionCommand.ExecuteCommand(accountId, id);

         if (!result.isSuccess) return BadRequest(result.Error);

         return Ok(result.Value);
      }
   }
}