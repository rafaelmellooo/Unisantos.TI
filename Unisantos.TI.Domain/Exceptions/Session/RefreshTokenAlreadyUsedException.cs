namespace Unisantos.TI.Domain.Exceptions.Session;

public class RefreshTokenAlreadyUsedException : Exception
{
    public RefreshTokenAlreadyUsedException() : base("Refresh Token já utilizado")
    {
    }
}