namespace Unisantos.TI.Domain.Providers.Security;

public interface IPasswordHashProvider
{
    string Hash(string password);

    bool Verify(string passwordHash, string password);
}