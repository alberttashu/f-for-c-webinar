using System;
using Transactions_After.Application;
using Transactions_After.Core;
using Transactions_After.Core.Entities;

namespace Transactions_After
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactionsParser = new TransactionsParser();

            var res = transactionsParser.ParseTransactions(new string[] { });


            var accountStorage = new AccountStorage();
            var transactionsImporter = new TransactionsImporter(accountStorage, transactionsParser);

            var accountGuid = Guid.Parse("a7fce19b-ab94-4e4f-891c-6003dce94aa0");
            var account = new Account(accountGuid);
            accountStorage.Save(account);

            while (Console.ReadLine() != "exit")
            {
                Console.WriteLine("Importing transactions...");
                transactionsImporter.ImportTransactions("transactions.txt", account.Id);

                var updatedAccount = accountStorage.Get(accountGuid);
                Console.WriteLine($"Account contains {updatedAccount.Transactions.Count} transactions");
            }
        }
    }
}
