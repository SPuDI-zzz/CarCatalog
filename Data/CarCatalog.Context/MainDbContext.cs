namespace CarCatalog.Context;

using CarCatalog.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

public class MainDbContext : DbContext
{
    public DbSet<CarMark> CarMarks { get; set; }
    public DbSet<Country> Countrys { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<CarGeneration> CarGenerations { get; set; }
    public DbSet<CarConfiguration> CarConfigurations { get; set; }
    public DbSet<CarBodyType> CarBodyTypes { get; set; }
    public DbSet<CarDriveType> CarDriveTypes { get; set; }
    public DbSet<CarEgineType> CarEgineTypes { get; set; }
    public DbSet<CarTransmission> CarTransmissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CarForSale> CarsForSale { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .ToTable("users");

        modelBuilder.Entity<UserRole>()
            .ToTable("user_roles");
        
        modelBuilder.Entity<IdentityUserToken<Guid>>()
            .ToTable("user_tokens");
        
        modelBuilder.Entity<IdentityUserRole<Guid>>()
            .ToTable("user_role_owners");
        
        modelBuilder.Entity<IdentityRoleClaim<Guid>>()
            .ToTable("user_role_claims");
        
        modelBuilder.Entity<IdentityUserLogin<Guid>>()
            .ToTable("user_logins");
        
        modelBuilder.Entity<IdentityUserClaim<Guid>>()
            .ToTable("user_claims");

        modelBuilder.Entity<Country>()
            .ToTable("countries");

        modelBuilder.Entity<CarMark>()
            .ToTable("car_marks");

        modelBuilder.Entity<CarMark>()
            .HasOne(x => x.Country)
            .WithMany(x => x.CarMarks)
            .HasForeignKey(x => x.IdCountry);

        modelBuilder.Entity<CarModel>()
            .ToTable("car_models");

        modelBuilder.Entity<CarModel>()
            .HasOne(x => x.CarMark)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.IdCarMark);

        modelBuilder.Entity<CarGeneration>()
            .ToTable("car_generations");

        modelBuilder.Entity<CarGeneration>()
            .HasOne(x => x.CarModel)
            .WithMany(x => x.CarGenerations)
            .HasForeignKey(x => x.IDCarModel);

        modelBuilder.Entity<CarBodyType>()
            .ToTable("car_body_types");

        modelBuilder.Entity<CarDriveType>()
            .ToTable("car_drive_types");

        modelBuilder.Entity<CarEgineType>()
            .ToTable("car_engine_types");

        modelBuilder.Entity<CarTransmission>()
            .ToTable("car_transmissions");

        modelBuilder.Entity<CarConfiguration>()
            .ToTable("car_configurations");

        modelBuilder.Entity<CarConfiguration>()
            .HasOne(x => x.CarGeneration)
            .WithMany(x => x.CarConfigurations)
            .HasForeignKey(x => x.IdCarGeneration);

        modelBuilder.Entity<CarConfiguration>()
            .HasOne(x => x.CarBodyType)
            .WithMany(x => x.CarConfigurations)
            .HasForeignKey(x => x.IdCarBodyType);

        modelBuilder.Entity<CarConfiguration>()
            .HasOne(x => x.CarDriveType)
            .WithMany(x => x.CarConfigurations)
            .HasForeignKey(x => x.IdCarDriveType);

        modelBuilder.Entity<CarConfiguration>()
            .HasOne(x => x.CarEgineType)
            .WithMany(x => x.CarConfigurations)
            .HasForeignKey(x => x.IdCarEgineType);

        modelBuilder.Entity<CarConfiguration>()
            .HasOne(x => x.CarTransmission)
            .WithMany(x => x.CarConfigurations)
            .HasForeignKey(x => x.IdCarTransmission);

        modelBuilder.Entity<CarForSale>()
            .ToTable("car_for_sales");

        modelBuilder.Entity<CarForSale>()
            .HasOne(x => x.CarConfiguration)
            .WithMany(x => x.CarForSales)
            .HasForeignKey(x => x.IdCarConfiguration);

        modelBuilder.Entity<CarForSale>()
            .HasMany(x => x.Users)
            .WithMany(x => x.CarForSales)
            .UsingEntity(t => t.ToTable("favorites"));

        modelBuilder.Entity<Comment>()
            .ToTable("comments");

        modelBuilder.Entity<Comment>()
            .HasOne(x => x.CarForSale)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.IdCarForSale);

        modelBuilder.Entity<Comment>()
            .HasOne(x => x.User)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.IdUser);
    }
}
