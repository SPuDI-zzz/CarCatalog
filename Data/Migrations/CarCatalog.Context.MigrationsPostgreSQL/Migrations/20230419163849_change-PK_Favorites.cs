using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class changePK_Favorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                table: "favorites");

            migrationBuilder.DropIndex(
                name: "IX_favorites_IdCarForSale",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "favorites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                table: "favorites",
                columns: new[] { "IdCarForSale", "IdUser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                table: "favorites");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "favorites",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                table: "favorites",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_IdCarForSale",
                table: "favorites",
                column: "IdCarForSale");
        }
    }
}
