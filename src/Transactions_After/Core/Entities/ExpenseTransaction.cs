using System;

namespace Transactions_After.Core.Entities
{
    public class ExpenseTransaction : TransactionBase 
    {
        public string ExpenseCategory { get; }

        public ExpenseTransaction(Guid id, decimal amount, string expenseCategory, DateTime transactionDate) 
            : base(id, amount, transactionDate)
        {
            ExpenseCategory = expenseCategory;
        }

        public override int GetHashCode()
        {
            return "Expense".GetHashCode()
                   + 7 * ExpenseCategory.GetHashCode()
                   + 13 * Amount.GetHashCode()
                   + 17 * TransactionDate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ExpenseTransaction;
            if (other == null)
            {
                return false;
            }

            return this.GetHashCode() == other.GetHashCode();
        }
    }
}
