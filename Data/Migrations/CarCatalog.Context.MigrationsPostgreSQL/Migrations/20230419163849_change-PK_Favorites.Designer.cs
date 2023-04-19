﻿// <auto-generated />
using System;
using CarCatalog.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230419163849_change-PK_Favorites")]
    partial class changePK_Favorites
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarCatalog.Context.Entities.CarBodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("car_body_types", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("EngineCapasity")
                        .HasColumnType("real");

                    b.Property<int>("HorsePower")
                        .HasColumnType("integer");

                    b.Property<int?>("IdCarBodyType")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("IdCarDriveType")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("IdCarEgineType")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("IdCarGeneration")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("IdCarTransmission")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<bool>("LeftHandWheel")
                        .HasColumnType("boolean");

                    b.Property<int>("Trunk")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdCarBodyType");

                    b.HasIndex("IdCarDriveType");

                    b.HasIndex("IdCarEgineType");

                    b.HasIndex("IdCarGeneration");

                    b.HasIndex("IdCarTransmission");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("car_configurations", null, t =>
                        {
                            t.HasCheckConstraint("\"EngineCapasity\"", "\"EngineCapasity\" >= 0")
                                .HasName("\"CK_CarConfiguration_EngineCapasity\"");

                            t.HasCheckConstraint("\"HorsePower\"", "\"HorsePower\" >= 0")
                                .HasName("\"CK_CarConfiguration_HorsePower\"");

                            t.HasCheckConstraint("\"Trunk\"", "\"Trunk\" >= 0")
                                .HasName("\"CK_CarConfiguration_Trunk\"");
                        });
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarDriveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("car_drive_types", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarEngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("car_engine_types", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarForSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("IdCarConfiguration")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdCarConfiguration");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("car_for_sales", null, t =>
                        {
                            t.HasCheckConstraint("\"Mileage\"", "\"Mileage\" >= 0")
                                .HasName("\"CK_CarForSale_Mileage\"");

                            t.HasCheckConstraint("\"Price\"", "\"Price\" >= 0")
                                .HasName("\"CK_CarForSale_Price\"");
                        });
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarGeneration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("IDCarModel")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.Property<int>("YearBegin")
                        .HasColumnType("integer");

                    b.Property<int?>("YearEnd")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IDCarModel");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("car_generations", null, t =>
                        {
                            t.HasCheckConstraint("\"YearBegin\"", "\"YearBegin\" >= 1900 AND \"YearBegin\" <= EXTRACT(Year FROM CURRENT_DATE)")
                                .HasName("\"CK_CarGeneration_YearBegin\"");

                            t.HasCheckConstraint("\"YearEnd\"", "\"YearEnd\" >= \"YearBegin\" AND \"YearEnd\" <= EXTRACT(Year FROM CURRENT_DATE)")
                                .HasName("\"CK_CarGeneration_YearEnd\"");
                        });
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdCountry")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("car_marks", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<int?>("IdCarMark")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdCarMark");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("car_models", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarTransmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("car_transmissions", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("IdCarForSale")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("IdUser")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdCarForSale");

                    b.HasIndex("IdUser");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.Favorite", b =>
                {
                    b.Property<int?>("IdCarForSale")
                        .HasColumnType("integer");

                    b.Property<int?>("IdUser")
                        .HasColumnType("integer");

                    b.HasKey("IdCarForSale", "IdUser")
                        .HasName("PK_favorites");

                    b.ToTable("favorites", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("user_role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("user_logins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_role_owners", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_tokens", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarConfiguration", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.CarBodyType", "CarBodyType")
                        .WithMany("CarConfigurations")
                        .HasForeignKey("IdCarBodyType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.CarDriveType", "CarDriveType")
                        .WithMany("CarConfigurations")
                        .HasForeignKey("IdCarDriveType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.CarEngineType", "CarEgineType")
                        .WithMany("CarConfigurations")
                        .HasForeignKey("IdCarEgineType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.CarGeneration", "CarGeneration")
                        .WithMany("CarConfigurations")
                        .HasForeignKey("IdCarGeneration")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.CarTransmission", "CarTransmission")
                        .WithMany("CarConfigurations")
                        .HasForeignKey("IdCarTransmission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBodyType");

                    b.Navigation("CarDriveType");

                    b.Navigation("CarEgineType");

                    b.Navigation("CarGeneration");

                    b.Navigation("CarTransmission");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarForSale", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.CarConfiguration", "CarConfiguration")
                        .WithMany("CarForSales")
                        .HasForeignKey("IdCarConfiguration")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarConfiguration");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarGeneration", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.CarModel", "CarModel")
                        .WithMany("CarGenerations")
                        .HasForeignKey("IDCarModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarMark", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.Country", "Country")
                        .WithMany("CarMarks")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarModel", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.CarMark", "CarMark")
                        .WithMany("CarModels")
                        .HasForeignKey("IdCarMark")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarMark");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.Comment", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.CarForSale", "CarForSale")
                        .WithMany("Comments")
                        .HasForeignKey("IdCarForSale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarForSale");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.Favorite", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.CarForSale", "CarForSale")
                        .WithMany("Favorites")
                        .HasForeignKey("IdCarForSale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("IdCarForSale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarForSale");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Context.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("CarCatalog.Context.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarBodyType", b =>
                {
                    b.Navigation("CarConfigurations");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarConfiguration", b =>
                {
                    b.Navigation("CarForSales");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarDriveType", b =>
                {
                    b.Navigation("CarConfigurations");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarEngineType", b =>
                {
                    b.Navigation("CarConfigurations");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarForSale", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarGeneration", b =>
                {
                    b.Navigation("CarConfigurations");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarMark", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarModel", b =>
                {
                    b.Navigation("CarGenerations");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.CarTransmission", b =>
                {
                    b.Navigation("CarConfigurations");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.Country", b =>
                {
                    b.Navigation("CarMarks");
                });

            modelBuilder.Entity("CarCatalog.Context.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Favorites");
                });
#pragma warning restore 612, 618
        }
    }
}
