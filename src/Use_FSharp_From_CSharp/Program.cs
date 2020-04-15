using System;
using Messages;

namespace Use_FSharp_From_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactionId = Guid.NewGuid();
            var sourceId = Guid.NewGuid();
            var targetId = Guid.NewGuid();

            var command1 = new CreateTransferTransaction(
                transactionId,
                100m,
                sourceId,
                targetId,
                "test transaction"
            );

            var command2 = new CreateTransferTransaction(
                transactionId,
                120m,
                targetId,
                sourceId,
                "test transaction"
            );

            var command3 = new CreateTransferTransaction(
                transactionId,
                100m,
                sourceId,
                targetId,
                "test transaction"
            );

            if (command1.Equals(command2))
            {
                Console.WriteLine("Commands 1 and 2 are equal");
            }
            else
            {
                Console.WriteLine("Commands 1 and 2 are not equal");
            }

            if (command1.Equals(command3))
            {
                Console.WriteLine("Commands 1 and 3 are equal");
            }
            else
            {
                Console.WriteLine("Commands 1 and 3 are not equal");
            }

            if (Object.ReferenceEquals(command1, command3))
            {
                Console.WriteLine("Commands 1 and 3 are equal by reference");
            }
            else
            {
                Console.WriteLine("Commands 1 and 3 are not equal by reference");
            }
        }
    }
}
