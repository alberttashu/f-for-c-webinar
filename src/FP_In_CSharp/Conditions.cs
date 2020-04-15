using System;
// ReSharper disable PossibleNullReferenceException

namespace FP_In_CSharp
{
    class Conditions
    {
        public static string ConditionsInProceduralWay(DateTime date, string logPath)
        {
            string result;
            var dateString = date.ToShortDateString();

            if (logPath.EndsWith(dateString))
            {
                result = logPath;
            }
            else
            {
                result = logPath.Substring(0, logPath.Length - dateString.Length) + dateString;
            }

            return result;
        }


        public static string ConditionsInFunctionalWay(DateTime date, string logPath)
        {
            var dateString = date.ToShortDateString();

            return logPath switch
            {
                var x when x.EndsWith(dateString) => logPath,
                _ => logPath.Substring(0, logPath.Length - dateString.Length) + dateString
            };
        }

    }
}
