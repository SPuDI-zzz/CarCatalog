namespace CarCatalog.Context;

using Microsoft.EntityFrameworkCore;

public static class DbContextOptionsFactory
{
    private const string migrationProjctPrefix = "CarCatalog.Context.Migrations";

    public static DbContextOptions<MainDbContext> Create(string connStr)
    {
        var bldr = new DbContextOptionsBuilder<MainDbContext>();

        Configure(connStr).Invoke(bldr);

        return bldr.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connStr)
    {
        return (bldr) =>
        {
            bldr.UseNpgsql(connStr,
                opts => opts
                        .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                        .MigrationsHistoryTable("_EFMigrationsHistory", "public")
                        .MigrationsAssembly($"{migrationProjctPrefix}PostgreSQL")
                );            

            bldr.EnableSensitiveDataLogging();
            bldr.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        };
    }
}
