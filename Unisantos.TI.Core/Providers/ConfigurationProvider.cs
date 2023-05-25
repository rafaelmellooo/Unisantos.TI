using Microsoft.Extensions.Configuration;
using Unisantos.TI.Domain.Settings;

namespace Unisantos.TI.Core.Providers;

public class ConfigurationProvider : Domain.Providers.IConfigurationProvider
{
    private readonly IConfiguration _configuration;

    public ConfigurationProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => _configuration.GetConnectionString("Default");

    public AuthSettings AuthSettings => _configuration.GetRequiredSection("AuthSettings").Get<AuthSettings>();
}