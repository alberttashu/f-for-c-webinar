using System.Collections.Generic;
using Transactions_Before.Entities;

namespace FSharp.Webinar
{
    internal interface ITransactionStorage
    {
        void AddTransaction(TransactionBase transaction);
        IReadOnlyList<TransactionBase> GetAll();
    }
}