using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.Providers;
using Unisantos.TI.Infrastructure.CompiledModels;

namespace Unisantos.TI.Infrastructure.Extensions;

public static class ApplicationDbContextExtensions
{
    public static void AddApplicationDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((service, options) =>
        {
            var connectionString = service.GetRequiredService<IConfigurationProvider>().ConnectionString;

            options.UseModel(ApplicationDbContextModel.Instance).UseNpgsql(connectionString);

            options.EnableSensitiveDataLogging();
        });
    }
}