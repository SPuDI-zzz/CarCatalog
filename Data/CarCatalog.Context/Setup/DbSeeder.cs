namespace CarCatalog.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeeder
{
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider) => serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    private static MainDbContext DbContext(IServiceProvider serviceProvider) => ServiceScope(serviceProvider).ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();

    //private static readonly string masterUserName = "Admin";
    //private static readonly string masterUserEmail = "admin@dsrnetscool.com";
    //private static readonly string masterUserPassword = "Pass123#";

    //private static void ConfigureAdministrator(IServiceScope scope)
    //{
    //    //    var defaults = scope.ServiceProvider.GetService<IDefaultsSettings>();

    //    //    if (defaults != null)
    //    //    {
    //    //        var userService = scope.ServiceProvider.GetService<IUserService>();
    //    //        if (addAdmin && (!userService?.Any() ?? false))
    //    //        {
    //    //            var user = userService.Create(new CreateUserModel
    //    //            {
    //    //                Type = UserType.ForPortal,
    //    //                Status = UserStatus.Active,
    //    //                Name = defaults.AdministratorName,
    //    //                Password = defaults.AdministratorPassword,
    //    //                Email = defaults.AdministratorEmail,
    //    //                IsEmailConfirmed = !defaults.AdministratorEmail.IsNullOrEmpty(),
    //    //                Phone = null,
    //    //                IsPhoneConfirmed = false,
    //    //                IsChangePasswordNeeded = true
    //    //            })
    //    //                .GetAwaiter()
    //    //                .GetResult();

    //    //            userService.SetUserRoles(user.Id, Infrastructure.User.UserRole.Administrator).GetAwaiter().GetResult();
    //    //        }
    //    //    }
    //}

    public static void Execute(IServiceProvider serviceProvider, bool addDemoData, bool addAdmin = true)
    {
        using var scope = ServiceScope(serviceProvider);
        ArgumentNullException.ThrowIfNull(scope);

        //if (addAdmin)
        //{
        //    ConfigureAdministrator(scope);
        //}

        if (addDemoData)
        {
            Task.Run(async () =>
            {
                await ConfigureDemoData(serviceProvider);
            });
        }
    }

    private static async Task ConfigureDemoData(IServiceProvider serviceProvider)
    {
        await AddCountries(serviceProvider);
        await AddCarDriveTypes(serviceProvider);
    }

    private static async Task AddCarDriveTypes(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarDriveTypes.Any())
        {
            return;
        }

        var item1 = new Entities.CarDriveType
        {
            Name = "Front-wheel",
        };
        context.CarDriveTypes.Add(item1);

        var item2 = new Entities.CarDriveType
        {
            Name = "Rear-wheel",
        };
        context.CarDriveTypes.Add(item2);

        var item3 = new Entities.CarDriveType
        {
            Name = "All-wheel",
        };
        context.CarDriveTypes.Add(item3);

        var item4 = new Entities.CarDriveType
        {
            Name = "Hybrid synergetic",
        };
        context.CarDriveTypes.Add(item4);

        context.SaveChanges();
    }

    private static async Task AddCountries(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        // TODO : add database filling
        if (context.Countries.Any())
        {
            return;
        }

        var item1 = new Entities.Country 
        { 
            Name = "Russia",
        };
        context.Countries.Add(item1);

        var item2 = new Entities.Country
        {
            Name = "USA",
        };
        context.Countries.Add(item2);

        context.SaveChanges();
    }
}