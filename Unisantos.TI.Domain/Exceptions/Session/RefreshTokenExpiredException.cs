namespace Unisantos.TI.Domain.Exceptions.Session;

public class RefreshTokenExpiredException : Exception
{
    public RefreshTokenExpiredException() : base("Refresh Token expirado")
    {
    }
}