namespace Unisantos.TI.Server.Responses;

public class SuccessResponse<TData>
{
    public SuccessResponse(TData data)
    {
        Data = data;
    }
    
    public TData Data { get; set; }
}