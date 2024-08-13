using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class renamingAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timezone",
                table: "Weathers",
                newName: "timezone");

            migrationBuilder.RenameColumn(
                name: "Lon",
                table: "Weathers",
                newName: "lon");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "Weathers",
                newName: "lat");

            migrationBuilder.RenameColumn(
                name: "StateCode",
                table: "Weathers",
                newName: "state_code");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Weathers",
                newName: "country_code");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Weathers",
                newName: "city_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timezone",
                table: "Weathers",
                newName: "Timezone");

            migrationBuilder.RenameColumn(
                name: "lon",
                table: "Weathers",
                newName: "Lon");

            migrationBuilder.RenameColumn(
                name: "lat",
                table: "Weathers",
                newName: "Lat");

            migrationBuilder.RenameColumn(
                name: "state_code",
                table: "Weathers",
                newName: "StateCode");

            migrationBuilder.RenameColumn(
                name: "country_code",
                table: "Weathers",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "city_name",
                table: "Weathers",
                newName: "CityName");
        }
    }
}
