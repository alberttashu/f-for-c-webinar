using System;
using System.IO;
using System.Linq;
using Transactions_Before.Entities;

namespace FSharp.Webinar
{
    class TransactionImporter
    {
        private readonly ITransactionStorage _transactionStorage;

        public TransactionImporter(ITransactionStorage transactionStorage)
        {
            _transactionStorage = transactionStorage;
        }

        public void ImportTransactions(string filePath)
        {
            var fileLines = File.ReadAllLines(filePath).Where(x=>!string.IsNullOrWhiteSpace(x));

            foreach (var line in fileLines)
            {
                var transaction = ParseTransaction(line);
                _transactionStorage.AddTransaction(transaction);
            }
        }

        private TransactionBase ParseTransaction(string line)
        {
            var segments = line.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Trim()).ToArray();
            var transactionType = segments.First();
            var transactionData = segments.Skip(1).ToArray();

            switch (transactionType)
            {
                case "income":
                    return ParseIncomeTransaction(transactionData);
                case "expense":
                    return ParseExpenseTransaction(transactionData);
                case "transfer":
                    return ParseTransferTransaction(transactionData);
                default:
                    throw new ArgumentException($"Unknown transaction type: {transactionType}");
            }
        }

        private TransferTransaction ParseTransferTransaction(string[] data)
        {
            var amount = decimal.Parse(data[0]);
            var source = data[1];
            var target = data[2];
            var date = DateTime.Parse(data[3]);
            return new TransferTransaction()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                Source = source,
                Target = target,
                TransactionDate = date
            }; ;
        }

        private ExpenseTransaction ParseExpenseTransaction(string[] data)
        {
            var amount = decimal.Parse(data[0]);
            var category = data[1];
            var date = DateTime.Parse(data[2]);
            return new ExpenseTransaction()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                ExpenseCategory = category,
                TransactionDate = date
            };
        }

        private IncomeTransaction ParseIncomeTransaction(string[] data)
        {
            var amount = decimal.Parse(data[0]);
            var category = data[1];
            var date = DateTime.Parse(data[2]);
            return new IncomeTransaction()
            {
                Id = Guid.NewGuid(),
                Amount = amount,
                IncomeCategory = category,
                TransactionDate = date
            };
        }
    }
}
