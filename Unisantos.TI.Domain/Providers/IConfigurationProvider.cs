using Unisantos.TI.Domain.Settings;

namespace Unisantos.TI.Domain.Providers;

public interface IConfigurationProvider
{
    string ConnectionString { get; }
    
    AuthSettings AuthSettings { get; }
}