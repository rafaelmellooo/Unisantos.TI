namespace Unisantos.TI.Domain.Exceptions.Session;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Usuário não encontrado")
    {
    }
}