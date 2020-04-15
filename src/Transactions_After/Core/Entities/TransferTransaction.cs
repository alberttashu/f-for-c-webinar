using System;

namespace Transactions_After.Core.Entities
{
    public class TransferTransaction : TransactionBase
    {
        public string Source { get; }
        public string Target { get; }

        public TransferTransaction(Guid id, decimal amount, string source, string target, DateTime transactionDate) 
            : base(id, amount, transactionDate)
        {
            Source = source;
            Target = target;
        }

        public override int GetHashCode()
        {
            return "Transfer".GetHashCode()
                   + 7 * Source.GetHashCode()
                   + 13 * Target.GetHashCode()
                   + 17 * Amount.GetHashCode()
                   + 19 * TransactionDate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as TransferTransaction;
            if (other == null)
            {
                return false;
            }

            return this.GetHashCode() == other.GetHashCode();
        }
    }
}
