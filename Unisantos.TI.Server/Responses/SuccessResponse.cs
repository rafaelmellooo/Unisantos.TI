namespace Unisantos.TI.Server.Responses;

public class SuccessResponse<TData>
{
    public TData? Data { get; set; }
    
    public SuccessResponse(TData? data)
    {
        Data = data;
    }
}