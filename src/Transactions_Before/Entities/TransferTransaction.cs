namespace Transactions_Before.Entities
{
    public class TransferTransaction : TransactionBase
    {
        public string Source { get; set; }

        public string Target { get; set; }

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
