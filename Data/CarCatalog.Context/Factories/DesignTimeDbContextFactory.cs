namespace CarCatalog.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    private const string migrationProjctPrefix = "CarCatalog.Context.Migrations";

    public MainDbContext CreateDbContext(string[] args)
    {
        var provider = (args.Length > 0 ? args[0] : "PostgreSQL").ToLower();

        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.context.json")
             .Build();

        DbContextOptions<MainDbContext> options;
        if (provider.Equals("PostgreSQL".ToLower()))
        {
            options = new DbContextOptionsBuilder<MainDbContext>()
                    .UseNpgsql(
                        configuration.GetConnectionString(provider),
                        opts => opts
                            .MigrationsAssembly($"{migrationProjctPrefix}PostgreSQL")
                    )
                    .Options;
        }
        else
        {
            throw new Exception($"Unsupported provider: {provider}");
        }

        var dbf = new DbContextFactory(options);
        return dbf.Create();
    }
}
