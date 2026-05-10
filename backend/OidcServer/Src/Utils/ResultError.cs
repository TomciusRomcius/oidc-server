namespace OidcServer.Utils;

public enum ResultErrorType
{
    Validation = 0,
    Forbidden = 1,
    InvalidOperation = 2,
}

public class ResultError
{
    public ResultErrorType ErrorType { get; }
    public string Message { get; }

    public ResultError(ResultErrorType errorType, string message)
    {
        ErrorType = errorType;
        Message = message;
    }
}
