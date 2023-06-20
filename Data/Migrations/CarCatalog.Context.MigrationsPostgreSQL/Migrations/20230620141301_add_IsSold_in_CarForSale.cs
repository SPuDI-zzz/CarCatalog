using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class add_IsSold_in_CarForSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "car_for_sales",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "car_for_sales");
        }
    }
}
