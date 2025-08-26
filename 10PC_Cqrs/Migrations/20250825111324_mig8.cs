using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _10PC_Cqrs.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Locations",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "AirportCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AirportId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AirportName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreaCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Locations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Locations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AirportName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AreaCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Locations",
                newName: "LocationName");
        }
    }
}
