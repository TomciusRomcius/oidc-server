namespace OidcServer.Utils;

public class Result<TValue>
{
    private readonly TValue? _value;
    private readonly ResultError? _error;
    
    public Result(TValue value)
    {
        _value = value;
    }

    public Result(ResultError error)
    {
        _error = error;
    }
    
    public bool Ok() => _error == null;
    
    public TValue GetValue()
    {
        return !Ok() 
            ? throw new InvalidOperationException("Trying to access the value from a failed result") 
            : _value!;
    }

    public ResultError GetError()
    {
        return Ok()
            ? throw new InvalidOperationException("Trying to access the error from a successful result")
            : _error!;
    }
}
