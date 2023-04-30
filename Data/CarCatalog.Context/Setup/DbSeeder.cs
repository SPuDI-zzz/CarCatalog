namespace CarCatalog.Context;

using CarCatalog.Common.Exceptions;
using CarCatalog.Common.Security;
using CarCatalog.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbSeeder
{
    private static RoleManager<UserRole> RoleManager(IServiceProvider serviceProvider) => ServiceScope(serviceProvider).ServiceProvider.GetRequiredService<RoleManager<UserRole>>();
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider) => serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    private static MainDbContext DbContext(IServiceProvider serviceProvider) => ServiceScope(serviceProvider).ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();

    public static void Execute(IServiceProvider serviceProvider, bool addDemoData, bool addAdmin = true)
    {
        using var scope = ServiceScope(serviceProvider);
        ArgumentNullException.ThrowIfNull(scope);

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
        await AddCarMarks(serviceProvider);
        await AddCarModels(serviceProvider);
        await AddCarGenerations(serviceProvider);
        await AddCarBodyTypes(serviceProvider);
        await AddCarDriveTypes(serviceProvider);
        await AddCarEngineTypes(serviceProvider);
        await AddCarTransmissions(serviceProvider);  
        await AddCarConfigurations(serviceProvider);
        await AddCarsForSale(serviceProvider);
        await AddUserRoles(serviceProvider);
    }

    private static async Task AddUserRoles(IServiceProvider serviceProvider)
    {
        var roleManager = RoleManager(serviceProvider);

        if (roleManager.Roles.Any())
        {
            return;
        }

        var result = await roleManager.CreateAsync(new UserRole()
        {
            Name = AppRoles.Admin,
        });

        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");

        result = await roleManager.CreateAsync(new UserRole()
        {
            Name = AppRoles.User,
        });

        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");

        result = await roleManager.CreateAsync(new UserRole()
        {
            Name = AppRoles.Seller,
        });

        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");
    }

    private static async Task AddCarConfigurations(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarConfigurations.Any())
        {
            return;
        }

        Entities.CarGeneration carGenerationC8 = context.CarGenerations
            .Where(x => x.Name == "C8")
            .First()
            ;

        Entities.CarDriveType carDriveTypeFront = context.CarDriveTypes
            .Where(x => x.Name == "Front-wheel")
            .First()
            ;

        Entities.CarEngineType carEngineTypeDiesel = context.CarEngineTypes
            .Where(x => x.Name == "Diesel")
            .First()
            ;

        Entities.CarBodyType carBodyTypeSedan = context.CarBodyTypes
            .Where(x => x.Name == "Sedan")
            .First()
            ;

        Entities.CarTransmission carTransmissionRobotic = context.CarTransmissions
            .Where(x => x.Name == "Robotic")
            .First()
            ;

        context.CarConfigurations.Add(new Entities.CarConfiguration
        {
            IdCarBodyType = carBodyTypeSedan.Id,
            IdCarEgineType = carEngineTypeDiesel.Id,
            IdCarDriveType = carDriveTypeFront.Id,
            IdCarGeneration = carGenerationC8.Id,
            IdCarTransmission = carTransmissionRobotic.Id,
            HorsePower = 163,
            Trunk = 530,
            EngineCapasity = (float)2.0,
            LeftHandWheel = true,            
        });

        context.CarConfigurations.Add(new Entities.CarConfiguration
        {
            IdCarBodyType = carBodyTypeSedan.Id,
            IdCarEgineType = carEngineTypeDiesel.Id,
            IdCarDriveType = carDriveTypeFront.Id,
            IdCarGeneration = carGenerationC8.Id,
            IdCarTransmission = carTransmissionRobotic.Id,
            HorsePower = 190,
            Trunk = 530,
            EngineCapasity = (float)2.0,
            LeftHandWheel = true,
        });

        context.CarConfigurations.Add(new Entities.CarConfiguration
        {
            IdCarBodyType = carBodyTypeSedan.Id,
            IdCarEgineType = carEngineTypeDiesel.Id,
            IdCarDriveType = carDriveTypeFront.Id,
            IdCarGeneration = carGenerationC8.Id,
            IdCarTransmission = carTransmissionRobotic.Id,
            HorsePower = 204,
            Trunk = 530,
            EngineCapasity = (float)2.0,
            LeftHandWheel = true,
        });

        context.SaveChanges();
    }

    private static async Task AddCarEngineTypes(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarEngineTypes.Any())
        {
            return;
        }

        context.CarEngineTypes.Add(new Entities.CarEngineType
        {
            Name = "Petrol",
        });

        context.CarEngineTypes.Add(new Entities.CarEngineType
        {
            Name = "Diesel",
        });

        context.CarEngineTypes.Add(new Entities.CarEngineType
        {
            Name = "Hybrid",
        });

        context.CarEngineTypes.Add(new Entities.CarEngineType
        {
            Name = "Gas",
        });

        context.SaveChanges();
    }

    private static async Task AddCarsForSale(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarsForSale.Any())
        {
            return;
        }

        Entities.CarConfiguration carConfiguration = context.CarConfigurations
            .Where(x => x.Id == 1)
            .First()
            ;

        context.CarsForSale.Add(new Entities.CarForSale
        {
            Color = "Blue",
            Mileage = 74_923,
            Price = 3_850_000,
            IdCarConfiguration = carConfiguration.Id,
        });

        context.CarsForSale.Add(new Entities.CarForSale
        {
            Color = "Black",
            Mileage = 157_564,
            Price = 3_200_000,
            IdCarConfiguration = carConfiguration.Id,
        });

        context.CarsForSale.Add(new Entities.CarForSale
        {
            Color = "Brown",
            Mileage = 90_000,
            Price = 3_800_000,
            IdCarConfiguration = carConfiguration.Id,
        });

        context.SaveChanges();

    }

    private static async Task AddCarGenerations(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarGenerations.Any())
        {
            return;
        }

        Entities.CarModel carModelA4 = context.CarModels
            .Where(x => x.Name == "A4")
            .First()
            ;

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C4",
            YearBegin = 1994,
            YearEnd = 1997,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C5",
            YearBegin = 1997,
            YearEnd = 2001,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C5 FaceLift",
            YearBegin = 2001,
            YearEnd = 2005,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C6",
            YearBegin = 2004,
            YearEnd = 2008,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C6 FaceLift",
            YearBegin = 2008,
            YearEnd = 2011,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C7",
            YearBegin = 2011,
            YearEnd = 2014,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C7 FaceLift",
            YearBegin = 2014,
            YearEnd = 2018,
            IDCarModel = carModelA4.Id,
        });

        context.CarGenerations.Add(new Entities.CarGeneration
        {
            Name = "C8",
            YearBegin = 2018,
            YearEnd = 2023,
            IDCarModel = carModelA4.Id,
        });

        context.SaveChanges();
    }

    private static async Task AddCarTransmissions(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarTransmissions.Any())
        {
            return;
        }

        context.CarTransmissions.Add(new Entities.CarTransmission
        {
            Name = "Manual",
        });

        context.CarTransmissions.Add(new Entities.CarTransmission
        {
            Name = "Automatic",
        });

        context.CarTransmissions.Add(new Entities.CarTransmission
        {
            Name = "Robotic",
        });

        context.CarTransmissions.Add(new Entities.CarTransmission
        {
            Name = "Variable",
        });

        context.SaveChanges();
    }

    private static async Task AddCarBodyTypes(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarBodyTypes.Any())
        {
            return;
        }

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Sedan",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Hatchback",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Wagon",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Liftback",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Coupe",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Cabriolet",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Roadster",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Stretch",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Targa",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "SUV",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Crossover",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Pickup",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Van",
        });

        context.CarBodyTypes.Add(new Entities.CarBodyType
        {
            Name = "Minivan",
        });

        context.SaveChanges();
    }

    private static async Task AddCarModels(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarModels.Any())
        {
            return;
        }

        Entities.CarMark audi = context.CarMarks
            .Where(x => x.Name == "Audi")
            .First()
            ;

        context.CarModels.Add(new Entities.CarModel
        {
            Name = "A6",
            Class = "E",
            IdCarMark = audi.Id,
        });

        context.CarModels.Add(new Entities.CarModel
        {
            Name = "A8",
            Class = "F",
            IdCarMark = audi.Id,
        });

        context.CarModels.Add(new Entities.CarModel
        {
            Name = "A4",
            Class = "D",
            IdCarMark = audi.Id,
        });

        context.SaveChanges();
    }

    private static async Task AddCarMarks(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarMarks.Any())
        {
            return;
        }

        Entities.Country germany = context.Countries
            .Where(c => c.Name == "Germany")
            .First()
            ;

        context.CarMarks.Add(new Entities.CarMark
        {
            Name = "BMW",
            IdCountry = germany.Id,
        });

        context.CarMarks.Add(new Entities.CarMark
        {
            Name = "Audi",
            IdCountry = germany.Id,
        });

        context.CarMarks.Add(new Entities.CarMark
        {
            Name = "Volkswagen",
            IdCountry = germany.Id,
        });

        context.CarMarks.Add(new Entities.CarMark
        {
            Name = "Porsche",
            IdCountry = germany.Id,
        });

        context.CarMarks.Add(new Entities.CarMark
        {
            Name = "Mercedes-Benz",
            IdCountry = germany.Id,
        });

        context.CarMarks.Add(new Entities.CarMark
        {
            Name = "Opel",
            IdCountry = germany.Id,
        });

        context.SaveChanges();
    }

    private static async Task AddCarDriveTypes(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.CarDriveTypes.Any())
        {
            return;
        }

        context.CarDriveTypes.Add(new Entities.CarDriveType
        {
            Name = "Front-wheel",
        });

        context.CarDriveTypes.Add(new Entities.CarDriveType
        {
            Name = "Rear-wheel",
        });

        context.CarDriveTypes.Add(new Entities.CarDriveType
        {
            Name = "All-wheel",
        });

        context.CarDriveTypes.Add(new Entities.CarDriveType
        {
            Name = "Hybrid synergetic",
        });

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

        context.Countries.Add(new Entities.Country
        {
            Name = "Russia",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "USA",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "Germany",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "France",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "Japan",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "South Korea",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "China",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "Sweden",
        });

        context.Countries.Add(new Entities.Country
        {
            Name = "Great Britain",
        });

        context.SaveChanges();
    }
}
