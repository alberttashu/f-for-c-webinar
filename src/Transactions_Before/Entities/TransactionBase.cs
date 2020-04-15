using System;

namespace Transactions_Before.Entities
{
    public abstract class TransactionBase : Entity
    {
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }
        
        public abstract override int GetHashCode();

        public abstract override bool Equals(object obj);
    }
}
