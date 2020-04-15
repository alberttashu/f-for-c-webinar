using System;

namespace FSharp.Webinar
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new TransactionStorage();
            var importer = new TransactionImporter(storage);
            new TransactionImporter(new TransactionStorage())
                .ImportTransactions("transactions.txt");
        }
    }
}
