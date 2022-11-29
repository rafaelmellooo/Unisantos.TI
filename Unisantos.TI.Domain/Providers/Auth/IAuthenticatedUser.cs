namespace Unisantos.TI.Domain.Providers.Auth;

public interface IAuthenticatedUser
{
    Guid? Id { get; }
}