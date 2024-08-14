using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class renamingDATUM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vis",
                table: "DataPoints",
                newName: "vis");

            migrationBuilder.RenameColumn(
                name: "Uv",
                table: "DataPoints",
                newName: "uv");

            migrationBuilder.RenameColumn(
                name: "Ts",
                table: "DataPoints",
                newName: "ts");

            migrationBuilder.RenameColumn(
                name: "Temp",
                table: "DataPoints",
                newName: "temp");

            migrationBuilder.RenameColumn(
                name: "Snow",
                table: "DataPoints",
                newName: "snow");

            migrationBuilder.RenameColumn(
                name: "Slp",
                table: "DataPoints",
                newName: "slp");

            migrationBuilder.RenameColumn(
                name: "Rh",
                table: "DataPoints",
                newName: "rh");

            migrationBuilder.RenameColumn(
                name: "Pres",
                table: "DataPoints",
                newName: "pres");

            migrationBuilder.RenameColumn(
                name: "Precip",
                table: "DataPoints",
                newName: "precip");

            migrationBuilder.RenameColumn(
                name: "Pop",
                table: "DataPoints",
                newName: "pop");

            migrationBuilder.RenameColumn(
                name: "Pod",
                table: "DataPoints",
                newName: "pod");

            migrationBuilder.RenameColumn(
                name: "Ozone",
                table: "DataPoints",
                newName: "ozone");

            migrationBuilder.RenameColumn(
                name: "Ghi",
                table: "DataPoints",
                newName: "ghi");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "DataPoints",
                newName: "dni");

            migrationBuilder.RenameColumn(
                name: "Dhi",
                table: "DataPoints",
                newName: "dhi");

            migrationBuilder.RenameColumn(
                name: "Dewpt",
                table: "DataPoints",
                newName: "dewpt");

            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "DataPoints",
                newName: "datetime");

            migrationBuilder.RenameColumn(
                name: "Clouds",
                table: "DataPoints",
                newName: "clouds");

            migrationBuilder.RenameColumn(
                name: "WindSpd",
                table: "DataPoints",
                newName: "wind_spd");

            migrationBuilder.RenameColumn(
                name: "WindGustSpd",
                table: "DataPoints",
                newName: "wind_gust_spd");

            migrationBuilder.RenameColumn(
                name: "WindDir",
                table: "DataPoints",
                newName: "wind_dir");

            migrationBuilder.RenameColumn(
                name: "WindCdirFull",
                table: "DataPoints",
                newName: "wind_cdir_full");

            migrationBuilder.RenameColumn(
                name: "WindCdir",
                table: "DataPoints",
                newName: "wind_cdir");

            migrationBuilder.RenameColumn(
                name: "TimestampUtc",
                table: "DataPoints",
                newName: "timestamp_utc");

            migrationBuilder.RenameColumn(
                name: "TimestampLocal",
                table: "DataPoints",
                newName: "timestamp_local");

            migrationBuilder.RenameColumn(
                name: "SolarRad",
                table: "DataPoints",
                newName: "solar_rad");

            migrationBuilder.RenameColumn(
                name: "SnowDepth",
                table: "DataPoints",
                newName: "snow_depth");

            migrationBuilder.RenameColumn(
                name: "CloudsMid",
                table: "DataPoints",
                newName: "clouds_mid");

            migrationBuilder.RenameColumn(
                name: "CloudsLow",
                table: "DataPoints",
                newName: "clouds_low");

            migrationBuilder.RenameColumn(
                name: "CloudsHi",
                table: "DataPoints",
                newName: "clouds_hi");

            migrationBuilder.RenameColumn(
                name: "AppTemp",
                table: "DataPoints",
                newName: "app_temp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vis",
                table: "DataPoints",
                newName: "Vis");

            migrationBuilder.RenameColumn(
                name: "uv",
                table: "DataPoints",
                newName: "Uv");

            migrationBuilder.RenameColumn(
                name: "ts",
                table: "DataPoints",
                newName: "Ts");

            migrationBuilder.RenameColumn(
                name: "temp",
                table: "DataPoints",
                newName: "Temp");

            migrationBuilder.RenameColumn(
                name: "snow",
                table: "DataPoints",
                newName: "Snow");

            migrationBuilder.RenameColumn(
                name: "slp",
                table: "DataPoints",
                newName: "Slp");

            migrationBuilder.RenameColumn(
                name: "rh",
                table: "DataPoints",
                newName: "Rh");

            migrationBuilder.RenameColumn(
                name: "pres",
                table: "DataPoints",
                newName: "Pres");

            migrationBuilder.RenameColumn(
                name: "precip",
                table: "DataPoints",
                newName: "Precip");

            migrationBuilder.RenameColumn(
                name: "pop",
                table: "DataPoints",
                newName: "Pop");

            migrationBuilder.RenameColumn(
                name: "pod",
                table: "DataPoints",
                newName: "Pod");

            migrationBuilder.RenameColumn(
                name: "ozone",
                table: "DataPoints",
                newName: "Ozone");

            migrationBuilder.RenameColumn(
                name: "ghi",
                table: "DataPoints",
                newName: "Ghi");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "DataPoints",
                newName: "Dni");

            migrationBuilder.RenameColumn(
                name: "dhi",
                table: "DataPoints",
                newName: "Dhi");

            migrationBuilder.RenameColumn(
                name: "dewpt",
                table: "DataPoints",
                newName: "Dewpt");

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "DataPoints",
                newName: "Datetime");

            migrationBuilder.RenameColumn(
                name: "clouds",
                table: "DataPoints",
                newName: "Clouds");

            migrationBuilder.RenameColumn(
                name: "wind_spd",
                table: "DataPoints",
                newName: "WindSpd");

            migrationBuilder.RenameColumn(
                name: "wind_gust_spd",
                table: "DataPoints",
                newName: "WindGustSpd");

            migrationBuilder.RenameColumn(
                name: "wind_dir",
                table: "DataPoints",
                newName: "WindDir");

            migrationBuilder.RenameColumn(
                name: "wind_cdir_full",
                table: "DataPoints",
                newName: "WindCdirFull");

            migrationBuilder.RenameColumn(
                name: "wind_cdir",
                table: "DataPoints",
                newName: "WindCdir");

            migrationBuilder.RenameColumn(
                name: "timestamp_utc",
                table: "DataPoints",
                newName: "TimestampUtc");

            migrationBuilder.RenameColumn(
                name: "timestamp_local",
                table: "DataPoints",
                newName: "TimestampLocal");

            migrationBuilder.RenameColumn(
                name: "solar_rad",
                table: "DataPoints",
                newName: "SolarRad");

            migrationBuilder.RenameColumn(
                name: "snow_depth",
                table: "DataPoints",
                newName: "SnowDepth");

            migrationBuilder.RenameColumn(
                name: "clouds_mid",
                table: "DataPoints",
                newName: "CloudsMid");

            migrationBuilder.RenameColumn(
                name: "clouds_low",
                table: "DataPoints",
                newName: "CloudsLow");

            migrationBuilder.RenameColumn(
                name: "clouds_hi",
                table: "DataPoints",
                newName: "CloudsHi");

            migrationBuilder.RenameColumn(
                name: "app_temp",
                table: "DataPoints",
                newName: "AppTemp");
        }
    }
}
