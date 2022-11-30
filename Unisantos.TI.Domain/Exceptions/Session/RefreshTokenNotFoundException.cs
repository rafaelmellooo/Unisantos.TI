namespace Unisantos.TI.Domain.Exceptions.Session;

public class RefreshTokenNotFoundException : Exception
{
    public RefreshTokenNotFoundException() : base("Refresh Token não encontrado")
    {
    }
}