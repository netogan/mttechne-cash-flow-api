using Cash.Flow.Api.Domain.Models;
using Cash.Flow.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cash.Flow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetTransactions()
        {
            return Ok(_transactionService.GetTransactions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            await _transactionService.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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
    }
}
