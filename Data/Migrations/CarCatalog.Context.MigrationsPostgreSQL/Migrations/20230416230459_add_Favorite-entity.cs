using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class add_Favoriteentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favorites_car_for_sales_CarForSalesId",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_users_UsersId",
                table: "favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                table: "favorites");

            migrationBuilder.DropIndex(
                name: "IX_favorites_UsersId",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "CarForSalesId",
                table: "favorites");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "favorites",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "favorites",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "IdCarForSale",
                table: "favorites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "favorites",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                table: "favorites",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_IdCarForSale",
                table: "favorites",
                column: "IdCarForSale");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_car_for_sales_IdCarForSale",
                table: "favorites",
                column: "IdCarForSale",
                principalTable: "car_for_sales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_users_IdCarForSale",
                table: "favorites",
                column: "IdCarForSale",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favorites_car_for_sales_IdCarForSale",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_users_IdCarForSale",
                table: "favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                table: "favorites");

            migrationBuilder.DropIndex(
                name: "IX_favorites_IdCarForSale",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "IdCarForSale",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "favorites");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "favorites",
                newName: "UsersId");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "favorites",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CarForSalesId",
                table: "favorites",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                table: "favorites",
                columns: new[] { "CarForSalesId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_favorites_UsersId",
                table: "favorites",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_car_for_sales_CarForSalesId",
                table: "favorites",
                column: "CarForSalesId",
                principalTable: "car_for_sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_users_UsersId",
                table: "favorites",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
