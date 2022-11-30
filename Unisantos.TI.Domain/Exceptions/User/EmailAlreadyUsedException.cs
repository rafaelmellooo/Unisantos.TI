namespace Unisantos.TI.Domain.Exceptions.User;

public class EmailAlreadyUsedException : Exception
{
    public EmailAlreadyUsedException() : base("Já existe um usuário com esse email")
    {
    }
}