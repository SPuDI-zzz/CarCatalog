using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_body_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_body_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_drive_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_drive_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_engine_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_engine_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Birthday = table.Column<DateTime>(type: "Date", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdCountry = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_marks_countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_role_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_role_claims_user_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "user_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_claims_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_logins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_user_logins_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role_owners",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_owners", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_user_role_owners_user_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "user_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_owners_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_user_tokens_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: false),
                    IdCarMark = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_models_car_marks_IdCarMark",
                        column: x => x.IdCarMark,
                        principalTable: "car_marks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "car_generations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    YearBegin = table.Column<int>(type: "integer", nullable: false),
                    YearEnd = table.Column<int>(type: "integer", nullable: false),
                    IDCarModel = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_generations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_generations_car_models_IDCarModel",
                        column: x => x.IDCarModel,
                        principalTable: "car_models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "car_configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Trunk = table.Column<int>(type: "integer", nullable: false),
                    HorsePower = table.Column<int>(type: "integer", nullable: false),
                    EngineCapasity = table.Column<float>(type: "real", nullable: false),
                    LeftHandWheel = table.Column<bool>(type: "boolean", nullable: false),
                    IdCarDriveType = table.Column<int>(type: "integer", nullable: true),
                    IdCarBodyType = table.Column<int>(type: "integer", nullable: true),
                    IdCarEgineType = table.Column<int>(type: "integer", nullable: true),
                    IdCarTransmission = table.Column<int>(type: "integer", nullable: true),
                    IdCarGeneration = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_configurations_car_body_types_IdCarBodyType",
                        column: x => x.IdCarBodyType,
                        principalTable: "car_body_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_configurations_car_drive_types_IdCarDriveType",
                        column: x => x.IdCarDriveType,
                        principalTable: "car_drive_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_configurations_car_engine_types_IdCarEgineType",
                        column: x => x.IdCarEgineType,
                        principalTable: "car_engine_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_configurations_car_generations_IdCarGeneration",
                        column: x => x.IdCarGeneration,
                        principalTable: "car_generations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_car_configurations_car_transmissions_IdCarTransmission",
                        column: x => x.IdCarTransmission,
                        principalTable: "car_transmissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "car_for_sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Mileage = table.Column<int>(type: "integer", nullable: false),
                    IdCarConfiguration = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_for_sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_for_sales_car_configurations_IdCarConfiguration",
                        column: x => x.IdCarConfiguration,
                        principalTable: "car_configurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IdCarForSale = table.Column<int>(type: "integer", nullable: true),
                    IdUser = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_car_for_sales_IdCarForSale",
                        column: x => x.IdCarForSale,
                        principalTable: "car_for_sales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comments_users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    CarForSalesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => new { x.CarForSalesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_favorites_car_for_sales_CarForSalesId",
                        column: x => x.CarForSalesId,
                        principalTable: "car_for_sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorites_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_configurations_IdCarBodyType",
                table: "car_configurations",
                column: "IdCarBodyType");

            migrationBuilder.CreateIndex(
                name: "IX_car_configurations_IdCarDriveType",
                table: "car_configurations",
                column: "IdCarDriveType");

            migrationBuilder.CreateIndex(
                name: "IX_car_configurations_IdCarEgineType",
                table: "car_configurations",
                column: "IdCarEgineType");

            migrationBuilder.CreateIndex(
                name: "IX_car_configurations_IdCarGeneration",
                table: "car_configurations",
                column: "IdCarGeneration");

            migrationBuilder.CreateIndex(
                name: "IX_car_configurations_IdCarTransmission",
                table: "car_configurations",
                column: "IdCarTransmission");

            migrationBuilder.CreateIndex(
                name: "IX_car_configurations_Uid",
                table: "car_configurations",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_car_for_sales_IdCarConfiguration",
                table: "car_for_sales",
                column: "IdCarConfiguration");

            migrationBuilder.CreateIndex(
                name: "IX_car_for_sales_Uid",
                table: "car_for_sales",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_car_generations_IDCarModel",
                table: "car_generations",
                column: "IDCarModel");

            migrationBuilder.CreateIndex(
                name: "IX_car_generations_Uid",
                table: "car_generations",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_car_marks_IdCountry",
                table: "car_marks",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_car_marks_Uid",
                table: "car_marks",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_car_models_IdCarMark",
                table: "car_models",
                column: "IdCarMark");

            migrationBuilder.CreateIndex(
                name: "IX_car_models_Uid",
                table: "car_models",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_IdCarForSale",
                table: "comments",
                column: "IdCarForSale");

            migrationBuilder.CreateIndex(
                name: "IX_comments_IdUser",
                table: "comments",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_UsersId",
                table: "favorites",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_UserId",
                table: "user_claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_logins_UserId",
                table: "user_logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_claims_RoleId",
                table: "user_role_claims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_owners_RoleId",
                table: "user_role_owners",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "user_roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_users_Uid",
                table: "users",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_role_claims");

            migrationBuilder.DropTable(
                name: "user_role_owners");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "car_for_sales");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "car_configurations");

            migrationBuilder.DropTable(
                name: "car_body_types");

            migrationBuilder.DropTable(
                name: "car_drive_types");

            migrationBuilder.DropTable(
                name: "car_engine_types");

            migrationBuilder.DropTable(
                name: "car_generations");

            migrationBuilder.DropTable(
                name: "car_transmissions");

            migrationBuilder.DropTable(
                name: "car_models");

            migrationBuilder.DropTable(
                name: "car_marks");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
