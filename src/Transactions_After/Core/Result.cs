namespace Transactions_After.Core
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string ErrorMessage { get; }

        public Result(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(true, null, value);
        }
        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(false, error, default);
        }
        public static Result Ok()
        {
            return new Result(true, null);
        }
        public static Result Fail(string error)
        {
            return new Result(false, error);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        public Result(bool isSuccess, string errorMessage, T value) : base(isSuccess, errorMessage)
        {
            Value = value;
        }
    }
}
