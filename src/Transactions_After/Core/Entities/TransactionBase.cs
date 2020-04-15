using System;

namespace Transactions_After.Core.Entities
{
    public abstract class TransactionBase : Entity
    {
        public decimal Amount { get; }

        public DateTime TransactionDate { get; }

        public string Description { get; set; }

        protected TransactionBase(Guid id, decimal amount, DateTime transactionDate) : base(id)
        {
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public abstract override int GetHashCode();

        public abstract override bool Equals(object obj);
    }
}
