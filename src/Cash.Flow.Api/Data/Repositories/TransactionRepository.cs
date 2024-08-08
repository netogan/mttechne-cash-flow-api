using Cash.Flow.Api.Data.Context;
using Cash.Flow.Api.Data.Repositories.Interfaces;
using Cash.Flow.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cash.Flow.Api.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public readonly CashFlowContext _context;

        public TransactionRepository(CashFlowContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransaction(int id) 
            => await _context.Transactions.FirstOrDefaultAsync(u => u.Id == id);

        public IEnumerable<Transaction> GetTransactions(DateOnly? createAt = null) 
        {
            var transactions = _context.Transactions;

            if (createAt != null)
            {
                return transactions.Where(e => DateOnly.FromDateTime(e.CreateAt) >= createAt);
            }

            return transactions;
        } 

        public async Task<Transaction> AddTransaction(Transaction transaction) 
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return await GetTransaction(transaction.Id);
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            var transactionExist = await GetTransaction(transaction.Id);
            
            if (transactionExist != null) 
            {
                _context.Entry(transactionExist).CurrentValues.SetValues(transaction);
            }
            else
            {
                await AddTransaction(transaction);
            }

            return await GetTransaction(transaction.Id);
        }

        public async Task DeleteTransaction(int id) 
        { 
            var transactionExist = await GetTransaction(id);

            if (transactionExist != null)
            { 
                _context.Transactions.Remove(transactionExist); 
                await _context.SaveChangesAsync();
            }
        }
    }
}
