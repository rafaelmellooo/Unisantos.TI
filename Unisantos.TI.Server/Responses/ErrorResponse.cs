namespace Unisantos.TI.Server.Responses;

public class ErrorResponse : BaseResponse
{
    public ErrorResponse(string message) : base(true, message)
    {
    }
}