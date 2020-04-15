using System;

namespace Transactions_After.Core.Entities
{
    public class IncomeTransaction : TransactionBase
    {
        public string IncomeCategory { get; }

        public IncomeTransaction(Guid id, decimal amount, string incomeCategory, DateTime transactionDate) 
            : base(id, amount, transactionDate)
        {
            IncomeCategory = incomeCategory;
        }

        public override int GetHashCode()
        {
            return "Income".GetHashCode()
                    + 7 * IncomeCategory.GetHashCode() 
                    + 13 * Amount.GetHashCode() 
                    + 17 * TransactionDate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as IncomeTransaction;
            if (other == null)
            {
                return false;
            }

            return this.GetHashCode() == other.GetHashCode();
        }
    }
}
