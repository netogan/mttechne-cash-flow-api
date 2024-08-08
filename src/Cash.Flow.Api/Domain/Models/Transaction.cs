using Cash.Flow.Api.Domain.Enums;

namespace Cash.Flow.Api.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateAt { get; set; }
        public TransactionType Type { get; set; }

    }
}
