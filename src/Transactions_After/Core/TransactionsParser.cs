using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Transactions_After.Core.Entities;

namespace Transactions_After.Core
{
    class TransactionsParser
    {
        public Result<List<TransactionBase>> ParseTransactions(string[] serializedTransactionLines)
        {
            if (serializedTransactionLines == null)
            {
                return Result.Fail<List<TransactionBase>>($"{nameof(serializedTransactionLines)} is null");
            }

            var results = serializedTransactionLines
                .Select(ParseTransaction)
                .ToList();

            return results.All(x => x.IsSuccess) 
                ? Result.Ok(results.Select(x => x.Value).ToList()) 
                : Result.Fail<List<TransactionBase>>("Invalid input data format");
        }

        private Result<TransactionBase> ParseTransaction(string line)
        {
            try
            {
                var segments = line.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                var transactionType = segments.First();
                var transactionData = segments.Skip(1).ToArray();

                TransactionBase transaction = transactionType switch
                {
                    "income" => ParseIncomeTransaction(transactionData),
                    "expense" => ParseExpenseTransaction(transactionData),
                    "transfer" => ParseTransferTransaction(transactionData),
                    _ => null
                };

                return transaction == null ? Result.Fail<TransactionBase>("Invalid transaction type") : Result.Ok(transaction);
            }
            catch (Exception)
            {
                return Result.Fail<TransactionBase>("Invalid input data format");
            }
        }

        private TransferTransaction ParseTransferTransaction(string[] data)
        {
            var amount = decimal.Parse(data[0]);
            var source = data[1];
            var target = data[2];
            var date = DateTime.Parse(data[3]);
            return new TransferTransaction(Guid.NewGuid(), amount, source, target, date);
        }

        private ExpenseTransaction ParseExpenseTransaction(string[] data)
        {
            var amount = decimal.Parse(data[0]);
            var category = data[1];
            var date = DateTime.Parse(data[2]);
            return new ExpenseTransaction(Guid.NewGuid(), amount, category, date);
        }

        private IncomeTransaction ParseIncomeTransaction(string[] data)
        {
            var amount = decimal.Parse(data[0]);
            var category = data[1];
            var date = DateTime.Parse(data[2]);
            return new IncomeTransaction(Guid.NewGuid(), amount, category, date);
        }
    }
}
