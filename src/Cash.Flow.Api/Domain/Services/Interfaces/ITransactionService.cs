using Cash.Flow.Api.Domain.Models;

namespace Cash.Flow.Api.Domain.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransaction(int id);
        IEnumerable<Transaction> GetTransactions();
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(Transaction transaction);
        Task DeleteTransaction(int id);
    }
}
