using System;
using System.Collections.Generic;
using System.Linq;
using Transactions_After.Core.SideEffects;

namespace Transactions_After.Core.Entities
{
    class Account : Entity
    {
        public List<TransactionBase> Transactions { get; }

        public Account(Guid id) : base(id)
        {
            Transactions = new List<TransactionBase>();
        }

        public SideEffect<Account> AddTransactions(List<TransactionBase> transactions)
        {
            var newTransactions = transactions.Where(newTransaction => Transactions.All(x => !x.Equals(newTransaction))).ToList();
            Transactions.AddRange(newTransactions);
            return new AddTransactionsSideEffect(Id, newTransactions);
        }
    }
}
