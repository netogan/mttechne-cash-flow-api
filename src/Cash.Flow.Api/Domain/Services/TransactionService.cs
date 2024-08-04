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

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactionRepository.GetTransactions();
        }

        public async Task<Transaction> AddTransaction(Transaction Transaction)
        {
            return await _transactionRepository.AddTransaction(Transaction);
        }

        public async Task<Transaction> UpdateTransaction(Transaction Transaction)
        {
            return await _transactionRepository.UpdateTransaction(Transaction);
        }

        public async Task DeleteTransaction(int id)
        {
            await _transactionRepository.DeleteTransaction(id);
        }
    }
}
