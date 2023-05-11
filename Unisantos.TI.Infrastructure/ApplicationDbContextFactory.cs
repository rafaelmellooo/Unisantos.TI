using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Unisantos.TI.Infrastructure;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        var connectionString = configuration.GetConnectionString("Default");
        builder.UseNpgsql(connectionString);

        return new ApplicationDbContext(builder.Options);
    }
}