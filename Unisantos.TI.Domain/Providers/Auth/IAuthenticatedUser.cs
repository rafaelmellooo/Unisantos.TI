namespace Unisantos.TI.Domain.Providers.Auth;

public interface IAuthenticatedUser
{
    public Guid Id { get; }
    
    public string Name { get; }
}