namespace Unisantos.TI.Domain.Exceptions.Session;

public class InvalidTokenException : Exception
{
    public InvalidTokenException() : base("Token inválido")
    {
    }
}