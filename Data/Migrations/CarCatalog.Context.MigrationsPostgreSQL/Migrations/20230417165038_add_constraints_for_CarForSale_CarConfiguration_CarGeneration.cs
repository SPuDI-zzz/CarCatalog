using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class add_constraints_for_CarForSale_CarConfiguration_CarGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarGeneration_YearBegin\"",
                table: "car_generations",
                sql: "\"YearBegin\" >= 1900 AND \"YearBegin\" <= EXTRACT(Year FROM CURRENT_DATE)");

            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarGeneration_YearEnd\"",
                table: "car_generations",
                sql: "\"YearEnd\" >= \"YearBegin\" AND \"YearEnd\" <= EXTRACT(Year FROM CURRENT_DATE)");

            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarForSale_Mileage\"",
                table: "car_for_sales",
                sql: "\"Mileage\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarForSale_Price\"",
                table: "car_for_sales",
                sql: "\"Price\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarConfiguration_EngineCapasity\"",
                table: "car_configurations",
                sql: "\"EngineCapasity\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarConfiguration_HorsePower\"",
                table: "car_configurations",
                sql: "\"HorsePower\" >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "\"CK_CarConfiguration_Trunk\"",
                table: "car_configurations",
                sql: "\"Trunk\" >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarGeneration_YearBegin\"",
                table: "car_generations");

            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarGeneration_YearEnd\"",
                table: "car_generations");

            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarForSale_Mileage\"",
                table: "car_for_sales");

            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarForSale_Price\"",
                table: "car_for_sales");

            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarConfiguration_EngineCapasity\"",
                table: "car_configurations");

            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarConfiguration_HorsePower\"",
                table: "car_configurations");

            migrationBuilder.DropCheckConstraint(
                name: "\"CK_CarConfiguration_Trunk\"",
                table: "car_configurations");
        }
    }
}
