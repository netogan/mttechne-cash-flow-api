using Cash.Flow.Api.Data.Repositories;
using Cash.Flow.Api.Data.Repositories.Interfaces;
using Cash.Flow.Api.Domain.Models;
using Cash.Flow.Api.Domain.Services.Interfaces;

namespace Cash.Flow.Api.Domain.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            return await _transactionRepository.GetTransaction(id);
        }

        public IEnumerable<Transaction> GetTransactions(DateOnly? createAt = null) 
            => _transactionRepository.GetTransactions(createAt);

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            transaction.CreateAt = DateTime.Now;

            return await _transactionRepository.AddTransaction(transaction);
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            return await _transactionRepository.UpdateTransaction(transaction);
        }

        public async Task DeleteTransaction(int id)
        {
            await _transactionRepository.DeleteTransaction(id);
        }
    }
}
