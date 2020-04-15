using System;

namespace FP_In_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = Calculator.Divide(1, 0);
            Console.WriteLine(result1);

            Console.WriteLine(DateTime.Now.ToShortDateString());

            var log1 = Conditions.ConditionsInProceduralWay(new DateTime(2020, 3, 3), "log_2020-04-14");
            
            var log2 = Conditions.ConditionsInFunctionalWay(new DateTime(2020, 3, 3), "log_2020-04-14");


            Console.WriteLine(log1);
            Console.WriteLine(log2);
        }
    }
}
