using Microsoft.Extensions.DependencyInjection;
using Unisantos.TI.Core.Providers;
using Unisantos.TI.Core.Providers.Auth;
using Unisantos.TI.Core.Providers.Security;
using Unisantos.TI.Domain.Providers;
using Unisantos.TI.Domain.Providers.Auth;
using Unisantos.TI.Domain.Providers.Security;

namespace Unisantos.TI.Infrastructure.Extensions;

public static class ProvidersExtensions
{
    public static void AddProviders(this IServiceCollection services)
    {
        services.AddSingleton<IConfigurationProvider, ConfigurationProvider>();
        services.AddSingleton<IPasswordHashProvider, Argon2HashProvider>();

        services.AddScoped<IAuthProvider, JwtAuthProvider>();
        services.AddScoped<IAuthenticatedUser, HttpContextAuthenticatedUser>();
    }
}