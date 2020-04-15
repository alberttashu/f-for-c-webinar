using System;
using System.IO;
using System.Linq;
using Transactions_After.Core;

namespace Transactions_After.Application
{
    class TransactionsImporter
    {
        private readonly TransactionsParser _transactionsParser;
        private readonly AccountStorage _accountStorage;

        public TransactionsImporter(AccountStorage accountStorage, TransactionsParser transactionsParser)
        {
            _accountStorage = accountStorage;
            _transactionsParser = transactionsParser;
        }

        public void ImportTransactions(string filePath, Guid accountId)
        {
            var lines = File.ReadAllLines(filePath)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();

            var transactionsResult = _transactionsParser.ParseTransactions(lines);

            if (transactionsResult.IsSuccess)
            {
                var account = _accountStorage.Get(accountId);
                var sideEffect = account.AddTransactions(transactionsResult.Value);
                _accountStorage.Apply(sideEffect);
            }
            else
            {
                Console.WriteLine(transactionsResult.ErrorMessage);
            }
        }
    }
}
