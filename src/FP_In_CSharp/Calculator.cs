namespace FP_In_CSharp
{
    static class Calculator
    {
        public static int Divide(int x, int y)
        {
            return x / y;
        }


        public static int Divide(int x, NonZeroInt y)
        {
            return x / y;
        }


        public static Result<int> Divide1(int x, int y)
        {
            if (y == 0)
            {
                return Result.Fail<int>("Cannot divide by zero");
            }

            return Result.Ok(x / y);
        }


    }
}
