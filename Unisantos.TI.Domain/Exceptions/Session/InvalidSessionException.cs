namespace Unisantos.TI.Domain.Exceptions.Session;

public class InvalidSessionException : Exception
{
    public InvalidSessionException() : base("E-mail e/ou senha inválidos")
    {
    }
}