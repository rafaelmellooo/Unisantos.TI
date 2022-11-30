namespace Unisantos.TI.Domain.Exceptions.Session;

public class RefreshTokenInvalidException : Exception
{
    public RefreshTokenInvalidException() : base("Refresh Token inválido")
    {
    }
}