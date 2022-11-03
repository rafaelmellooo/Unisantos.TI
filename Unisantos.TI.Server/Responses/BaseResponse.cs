namespace Unisantos.TI.Server.Responses;

public abstract class BaseResponse
{
    protected BaseResponse()
    {
    }

    protected BaseResponse(bool error, string message)
    {
        Error = error;
        Message = message;
    }

    public bool Error { get; set; }

    public string Message { get; set; }
}