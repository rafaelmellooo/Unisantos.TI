using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Unisantos.TI.Functions.Startup))]
namespace Unisantos.TI.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        //builder.Services.AddProviders();

        //builder.Services.AddUseCases();
    }
}
