using Isopoh.Cryptography.Argon2;
using Unisantos.TI.Domain.Providers.Security;

namespace Unisantos.TI.Core.Providers.Security;

public class Argon2HashProvider : IPasswordHashProvider
{
    public string Hash(string password)
    {
        return Argon2.Hash(password, 1, 1024);
    }

    public bool Verify(string passwordHash, string password)
    {
        return Argon2.Verify(passwordHash, password);
    }
}