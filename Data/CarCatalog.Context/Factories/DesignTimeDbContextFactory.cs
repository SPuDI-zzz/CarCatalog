namespace CarCatalog.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    private const string migrationProjctPrefix = "CarCatalog.Context.Migrations";

    public MainDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.context.json")
             .Build();

        DbContextOptions<MainDbContext> options;
        options = new DbContextOptionsBuilder<MainDbContext>()
                .UseNpgsql(
                    configuration.GetConnectionString("postgresql"),
                    opts => opts
                        .MigrationsAssembly($"{migrationProjctPrefix}PostgreSQL")
                )
                .Options;

        var dbf = new DbContextFactory(options);
        return dbf.Create();
    }
}
