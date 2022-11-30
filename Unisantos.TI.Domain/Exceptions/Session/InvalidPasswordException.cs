namespace Unisantos.TI.Domain.Exceptions.Session;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Senha inválida")
    {
    }
}