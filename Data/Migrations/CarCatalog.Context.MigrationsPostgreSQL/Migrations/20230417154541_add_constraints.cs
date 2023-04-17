using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCatalog.Context.MigrationsPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class add_constraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_body_types_IdCarBodyType",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_drive_types_IdCarDriveType",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_engine_types_IdCarEgineType",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_generations_IdCarGeneration",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_transmissions_IdCarTransmission",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_for_sales_car_configurations_IdCarConfiguration",
                table: "car_for_sales");

            migrationBuilder.DropForeignKey(
                name: "FK_car_generations_car_models_IDCarModel",
                table: "car_generations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_marks_countries_IdCountry",
                table: "car_marks");

            migrationBuilder.DropForeignKey(
                name: "FK_car_models_car_marks_IdCarMark",
                table: "car_models");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_car_for_sales_IdCarForSale",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_IdUser",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_car_for_sales_IdCarForSale",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_users_IdCarForSale",
                table: "favorites");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "favorites",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarForSale",
                table: "favorites",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "countries",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarForSale",
                table: "comments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_transmissions",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_models",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarMark",
                table: "car_models",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "car_models",
                type: "character varying(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_marks",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "IdCountry",
                table: "car_marks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "YearEnd",
                table: "car_generations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_generations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "IDCarModel",
                table: "car_generations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarConfiguration",
                table: "car_for_sales",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "car_for_sales",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_engine_types",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_drive_types",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarTransmission",
                table: "car_configurations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarGeneration",
                table: "car_configurations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarEgineType",
                table: "car_configurations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarDriveType",
                table: "car_configurations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarBodyType",
                table: "car_configurations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_body_types",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_body_types_IdCarBodyType",
                table: "car_configurations",
                column: "IdCarBodyType",
                principalTable: "car_body_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_drive_types_IdCarDriveType",
                table: "car_configurations",
                column: "IdCarDriveType",
                principalTable: "car_drive_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_engine_types_IdCarEgineType",
                table: "car_configurations",
                column: "IdCarEgineType",
                principalTable: "car_engine_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_generations_IdCarGeneration",
                table: "car_configurations",
                column: "IdCarGeneration",
                principalTable: "car_generations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_transmissions_IdCarTransmission",
                table: "car_configurations",
                column: "IdCarTransmission",
                principalTable: "car_transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_for_sales_car_configurations_IdCarConfiguration",
                table: "car_for_sales",
                column: "IdCarConfiguration",
                principalTable: "car_configurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_generations_car_models_IDCarModel",
                table: "car_generations",
                column: "IDCarModel",
                principalTable: "car_models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_marks_countries_IdCountry",
                table: "car_marks",
                column: "IdCountry",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_car_models_car_marks_IdCarMark",
                table: "car_models",
                column: "IdCarMark",
                principalTable: "car_marks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_car_for_sales_IdCarForSale",
                table: "comments",
                column: "IdCarForSale",
                principalTable: "car_for_sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_IdUser",
                table: "comments",
                column: "IdUser",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_car_for_sales_IdCarForSale",
                table: "favorites",
                column: "IdCarForSale",
                principalTable: "car_for_sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_users_IdCarForSale",
                table: "favorites",
                column: "IdCarForSale",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_body_types_IdCarBodyType",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_drive_types_IdCarDriveType",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_engine_types_IdCarEgineType",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_generations_IdCarGeneration",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_configurations_car_transmissions_IdCarTransmission",
                table: "car_configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_for_sales_car_configurations_IdCarConfiguration",
                table: "car_for_sales");

            migrationBuilder.DropForeignKey(
                name: "FK_car_generations_car_models_IDCarModel",
                table: "car_generations");

            migrationBuilder.DropForeignKey(
                name: "FK_car_marks_countries_IdCountry",
                table: "car_marks");

            migrationBuilder.DropForeignKey(
                name: "FK_car_models_car_marks_IdCarMark",
                table: "car_models");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_car_for_sales_IdCarForSale",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_IdUser",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_car_for_sales_IdCarForSale",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_users_IdCarForSale",
                table: "favorites");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "favorites",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarForSale",
                table: "favorites",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "countries",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "comments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarForSale",
                table: "comments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_transmissions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_models",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarMark",
                table: "car_models",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "car_models",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_marks",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "IdCountry",
                table: "car_marks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "YearEnd",
                table: "car_generations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_generations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "IDCarModel",
                table: "car_generations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarConfiguration",
                table: "car_for_sales",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "car_for_sales",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_engine_types",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_drive_types",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "IdCarTransmission",
                table: "car_configurations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarGeneration",
                table: "car_configurations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarEgineType",
                table: "car_configurations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarDriveType",
                table: "car_configurations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "IdCarBodyType",
                table: "car_configurations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "car_body_types",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_body_types_IdCarBodyType",
                table: "car_configurations",
                column: "IdCarBodyType",
                principalTable: "car_body_types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_drive_types_IdCarDriveType",
                table: "car_configurations",
                column: "IdCarDriveType",
                principalTable: "car_drive_types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_engine_types_IdCarEgineType",
                table: "car_configurations",
                column: "IdCarEgineType",
                principalTable: "car_engine_types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_generations_IdCarGeneration",
                table: "car_configurations",
                column: "IdCarGeneration",
                principalTable: "car_generations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_configurations_car_transmissions_IdCarTransmission",
                table: "car_configurations",
                column: "IdCarTransmission",
                principalTable: "car_transmissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_for_sales_car_configurations_IdCarConfiguration",
                table: "car_for_sales",
                column: "IdCarConfiguration",
                principalTable: "car_configurations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_generations_car_models_IDCarModel",
                table: "car_generations",
                column: "IDCarModel",
                principalTable: "car_models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_marks_countries_IdCountry",
                table: "car_marks",
                column: "IdCountry",
                principalTable: "countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_models_car_marks_IdCarMark",
                table: "car_models",
                column: "IdCarMark",
                principalTable: "car_marks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_car_for_sales_IdCarForSale",
                table: "comments",
                column: "IdCarForSale",
                principalTable: "car_for_sales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_IdUser",
                table: "comments",
                column: "IdUser",
                principalTable: "users",
                principalColumn: "Id");

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
    }
}
