namespace Unisantos.TI.Server.Responses;

public class SuccessResponse<TData> : BaseResponse
{
    public TData? Data { get; set; }
    
    public SuccessResponse(TData? data)
    {
        Data = data;
    }
}