namespace Transactions_Before.Entities
{
    public class IncomeTransaction : TransactionBase
    {
        public string IncomeCategory { get; set; }

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
