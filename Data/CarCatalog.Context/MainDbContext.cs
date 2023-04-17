namespace CarCatalog.Context;

using CarCatalog.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

public class MainDbContext : IdentityDbContext<User, UserRole, int>
{
    public DbSet<CarMark> CarMarks { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<CarGeneration> CarGenerations { get; set; }
    public DbSet<CarConfiguration> CarConfigurations { get; set; }
    public DbSet<CarBodyType> CarBodyTypes { get; set; }
    public DbSet<CarDriveType> CarDriveTypes { get; set; }
    public DbSet<CarEngineType> CarEngineTypes { get; set; }
    public DbSet<CarTransmission> CarTransmissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CarForSale> CarsForSale { get; set; }
    public DbSet<Favorite> Favorites { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .ToTable("users");

        modelBuilder.Entity<UserRole>()
            .ToTable("user_roles");
        
        modelBuilder.Entity<IdentityUserToken<int>>()
            .ToTable("user_tokens");
        
        modelBuilder.Entity<IdentityUserRole<int>>()
            .ToTable("user_role_owners");
        
        modelBuilder.Entity<IdentityRoleClaim<int>>()
            .ToTable("user_role_claims");
        
        modelBuilder.Entity<IdentityUserLogin<int>>()
            .ToTable("user_logins");
        
        modelBuilder.Entity<IdentityUserClaim<int>>()
            .ToTable("user_claims");

        modelBuilder.Entity<Country>()
            .ToTable("countries");

        modelBuilder.Entity<Country>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<Country>()
            .Property(x => x.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<CarMark>()
            .ToTable("car_marks");

        modelBuilder.Entity<CarMark>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarMark>()
            .Property(x => x.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<CarMark>()
            .HasOne(x => x.Country)
            .WithMany(x => x.CarMarks)
            .HasForeignKey(x => x.IdCountry);

        modelBuilder.Entity<CarMark>()
            .Property(x => x.IdCountry)
            .IsRequired();

        modelBuilder.Entity<CarModel>()
            .ToTable("car_models");

        modelBuilder.Entity<CarModel>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarModel>()
            .Property(x => x.Name)
            .HasMaxLength(50);

        modelBuilder.Entity<CarModel>()
            .Property(x => x.Class)
            .IsRequired();

        modelBuilder.Entity<CarModel>()
            .Property(x => x.Class)
            .HasMaxLength(1);

        modelBuilder.Entity<CarModel>()
            .HasOne(x => x.CarMark)
            .WithMany(x => x.CarModels)
            .HasForeignKey(x => x.IdCarMark);

        modelBuilder.Entity<CarModel>()
            .Property(x => x.IdCarMark)
            .IsRequired();

        modelBuilder.Entity<CarGeneration>()
            .ToTable("car_generations");

        modelBuilder.Entity<CarGeneration>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarGeneration>()
            .Property(x => x.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<CarGeneration>()
            .Property(x => x.YearBegin)
            .IsRequired();

        modelBuilder.Entity<CarGeneration>()
            .ToTable(t => t.HasCheckConstraint("'YearBegin'", "'YearBegin' >= 1900 AND 'YearBegin' <= EXTRACT('Year' FROM CURRENT_DATE)")
                .HasName("'CK_CarGeneration_YearBegin'"));

        modelBuilder.Entity<CarGeneration>()
            .ToTable(t => t.HasCheckConstraint("'YearEnd'", "'YearEnd' >= 'YearBegin' AND 'YearEnd' <= EXTRACT('Year' FROM CURRENT_DATE)")
                .HasName("'CK_CarGeneration_YearEnd'"));

        modelBuilder.Entity<CarGeneration>()
            .Property(x => x.YearEnd)
            .IsRequired(false);

        modelBuilder.Entity<CarGeneration>()
            .HasOne(x => x.CarModel)
            .WithMany(x => x.CarGenerations)
            .HasForeignKey(x => x.IDCarModel);

        modelBuilder.Entity<CarGeneration>()
            .Property(x => x.IDCarModel)
            .IsRequired();

        modelBuilder.Entity<CarBodyType>()
            .ToTable("car_body_types");

        modelBuilder.Entity<CarBodyType>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarBodyType>()
            .Property(x => x.Name)
            .HasMaxLength(25);

        modelBuilder.Entity<CarDriveType>()
            .ToTable("car_drive_types");

        modelBuilder.Entity<CarDriveType>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarDriveType>()
            .Property(x => x.Name)
            .HasMaxLength(25);

        modelBuilder.Entity<CarEngineType>()
            .ToTable("car_engine_types");

        modelBuilder.Entity<CarEngineType>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarEngineType>()
            .Property(x => x.Name)
            .HasMaxLength(25);

        modelBuilder.Entity<CarTransmission>()
            .ToTable("car_transmissions");

        modelBuilder.Entity<CarTransmission>()
            .Property(x => x.Name)
            .IsRequired();

        modelBuilder.Entity<CarTransmission>()
            .Property(x => x.Name)
            .HasMaxLength(25);

        modelBuilder.Entity<CarConfiguration>()
            .ToTable("car_configurations");

        modelBuilder.Entity<CarConfiguration>()
            .ToTable(t => t.HasCheckConstraint("'Trunk'", "'Trunk' >= 0")
            .HasName("'CK_CarConfiguration_Trunk'"));

        modelBuilder.Entity<CarConfiguration>()
            .ToTable(t => t.HasCheckConstraint("'HorsePower'", "'HorsePower' >= 0")
            .HasName("'CK_CarConfiguration_HorsePower'"));

        modelBuilder.Entity<CarConfiguration>()
            .ToTable(t => t.HasCheckConstraint("'EngineCapasity'", "'EngineCapasity' >= 0")
            .HasName("'CK_CarConfiguration_EngineCapasity'"));

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

        modelBuilder.Entity<CarConfiguration>()
            .Property(x => x.IdCarBodyType)
            .IsRequired();

        modelBuilder.Entity<CarConfiguration>()
            .Property(x => x.IdCarTransmission)
            .IsRequired();

        modelBuilder.Entity<CarConfiguration>()
            .Property(x => x.IdCarDriveType)
            .IsRequired();

        modelBuilder.Entity<CarConfiguration>()
            .Property(x => x.IdCarEgineType)
            .IsRequired();

        modelBuilder.Entity<CarConfiguration>()
            .Property(x => x.IdCarGeneration)
            .IsRequired();

        modelBuilder.Entity<CarConfiguration>()
            .Property(x => x.IdCarTransmission)
            .IsRequired();

        modelBuilder.Entity<CarForSale>()
            .ToTable("car_for_sales");

        modelBuilder.Entity<CarForSale>()
            .ToTable(t => t.HasCheckConstraint("'Price'", "'Price' >= 0")
            .HasName("'CK_CarForSale_Price'"));

        modelBuilder.Entity<CarForSale>()
            .ToTable(t => t.HasCheckConstraint("'Mileage'", "'Mileage' >= 0")
            .HasName("'CK_CarForSale_Mileage'"));

        modelBuilder.Entity<CarForSale>()
            .Property(x => x.Color)
            .HasMaxLength(50);

        modelBuilder.Entity<CarForSale>()
            .HasOne(x => x.CarConfiguration)
            .WithMany(x => x.CarForSales)
            .HasForeignKey(x => x.IdCarConfiguration);

        modelBuilder.Entity<CarForSale>()
            .Property(x => x.IdCarConfiguration)
            .IsRequired();

        modelBuilder.Entity<Favorite>()
            .ToTable("favorites");

        modelBuilder.Entity<Favorite>()
            .HasOne(x => x.CarForSale)
            .WithMany(x => x.Favorites)
            .HasForeignKey(x => x.IdCarForSale);

        modelBuilder.Entity<Favorite>()
            .HasOne(x => x.User)
            .WithMany(x => x.Favorites)
            .HasForeignKey(x => x.IdCarForSale);

        modelBuilder.Entity<Favorite>()
            .Property(x => x.IdCarForSale)
            .IsRequired();

        modelBuilder.Entity<Favorite>()
            .Property(x => x.IdUser)
            .IsRequired();

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

        modelBuilder.Entity<Comment>()
            .Property(x => x.IdUser)
            .IsRequired();

        modelBuilder.Entity<Comment>()
            .Property(x => x.IdCarForSale)
            .IsRequired();
    }
}
