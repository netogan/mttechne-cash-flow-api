using Cash.Flow.Api.Domain.Models;

namespace Cash.Flow.Api.Data.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransaction(int id);
        IEnumerable<Transaction> GetTransactions(DateOnly? createAt = null);
        Task<Transaction> AddTransaction(Transaction user);
        Task<Transaction> UpdateTransaction(Transaction user);
        Task DeleteTransaction(int id);
    }
}
