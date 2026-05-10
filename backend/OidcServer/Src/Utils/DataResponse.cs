namespace OidcServer.Utils;

public class DataResponse<TData>
{
    public TData Data { get; set; }
    
    public DataResponse(TData data)
    {
        Data = data;
    }
}
