namespace OidcServer.Utils;

public enum ResultErrorType
{
    Validation = 0,
    Forbidden = 1,
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
