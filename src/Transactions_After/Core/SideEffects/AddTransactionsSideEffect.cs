using System;
using System.Collections.Generic;
using Transactions_After.Core.Entities;

namespace Transactions_After.Core.SideEffects
{
    class AddTransactionsSideEffect : SideEffect<Account>
    {
        public List<TransactionBase> Transactions { get; }

        public AddTransactionsSideEffect(Guid accountId, List<TransactionBase> transactions) : base(accountId)
        {
            Transactions = transactions;
        }

        public override void Apply(Account entity)
        {
            entity.Transactions.AddRange(Transactions);
        }
    }
}