using Cash.Flow.Api.Domain.Models;
using Cash.Flow.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cash.Flow.Api.Controllers
{
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private const string RouteApi = "api/[controller]";

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet(RouteApi)]
        [Authorize]
        public ActionResult<IEnumerable<Transaction>> GetTransactions(DateOnly? createAt = null)
        {
            return Ok(_transactionService.GetTransactions(createAt));
        }

        [HttpGet(RouteApi + "{id}")]
        [Authorize]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;
        }

        [HttpPost(RouteApi)]
        [Authorize]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            await _transactionService.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut(RouteApi + "{id}")]
        [Authorize]
        public async Task<IActionResult> PutTransaction(Transaction transaction)
        {
            var existingTransaction = await _transactionService.GetTransaction(transaction.Id);
            if (existingTransaction == null)
            {
                return NotFound();
            }
            await _transactionService.UpdateTransaction(transaction);
            return AcceptedAtAction(nameof(GetTransaction), new { id = transaction.Id }, existingTransaction);
        }

        [HttpDelete(RouteApi + "{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            await _transactionService.DeleteTransaction(id);
            return NoContent();
        }

        [HttpGet("api/internal/[controller]")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<IEnumerable<Transaction>> GetTransactionsInternal(DateOnly? createAt = null)
        {
            return Ok(_transactionService.GetTransactions(createAt));
        }
    }
}
