using System.Collections.Generic;
using Transactions_Before.Entities;

namespace FSharp.Webinar
{
    class TransactionStorage : ITransactionStorage
    {
        private readonly List<TransactionBase> _storage;

        public TransactionStorage()
        {
            _storage = new List<TransactionBase>();
        }

        public TransactionStorage(List<TransactionBase> seedTransactions)
        {
            _storage = seedTransactions;
        }

        public void AddTransaction(TransactionBase transaction)
        {
            _storage.Add(transaction);
        }

        public IReadOnlyList<TransactionBase> GetAll()
        {
            return _storage.AsReadOnly();
        }
    }
}
