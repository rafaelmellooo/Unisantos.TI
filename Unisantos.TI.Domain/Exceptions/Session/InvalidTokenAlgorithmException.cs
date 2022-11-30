namespace Unisantos.TI.Domain.Exceptions.Session;

public class InvalidTokenAlgorithmException : Exception
{
    public InvalidTokenAlgorithmException() : base("Token não usa o algoritmo correto")
    {
    }
}