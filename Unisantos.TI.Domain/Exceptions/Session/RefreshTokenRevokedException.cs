namespace Unisantos.TI.Domain.Exceptions.Session;

public class RefreshTokenRevokedException : Exception
{
    public RefreshTokenRevokedException() : base("Refresh Token revogado")
    {
    }
}