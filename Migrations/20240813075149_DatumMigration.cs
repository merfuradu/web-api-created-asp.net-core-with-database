using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class DatumMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    StateCode = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false),
                    Timezone = table.Column<string>(type: "text", nullable: false),
                    Lon = table.Column<float>(type: "real", nullable: false),
                    Lat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WId);
                });

            migrationBuilder.CreateTable(
                name: "DataPoints",
                columns: table => new
                {
                    DId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SnowDepth = table.Column<int>(type: "integer", nullable: false),
                    Dni = table.Column<int>(type: "integer", nullable: false),
                    WindCdir = table.Column<string>(type: "text", nullable: false),
                    Rh = table.Column<int>(type: "integer", nullable: false),
                    Pod = table.Column<string>(type: "text", nullable: false),
                    Ozone = table.Column<int>(type: "integer", nullable: false),
                    Pres = table.Column<int>(type: "integer", nullable: false),
                    CloudsHi = table.Column<int>(type: "integer", nullable: false),
                    Clouds = table.Column<int>(type: "integer", nullable: false),
                    Vis = table.Column<float>(type: "real", nullable: false),
                    WindSpd = table.Column<float>(type: "real", nullable: false),
                    WindCdirFull = table.Column<string>(type: "text", nullable: false),
                    Slp = table.Column<int>(type: "integer", nullable: false),
                    Datetime = table.Column<string>(type: "text", nullable: false),
                    Ts = table.Column<int>(type: "integer", nullable: false),
                    Snow = table.Column<int>(type: "integer", nullable: false),
                    Dewpt = table.Column<float>(type: "real", nullable: false),
                    Uv = table.Column<int>(type: "integer", nullable: false),
                    WindDir = table.Column<int>(type: "integer", nullable: false),
                    Ghi = table.Column<int>(type: "integer", nullable: false),
                    Dhi = table.Column<int>(type: "integer", nullable: false),
                    WindGustSpd = table.Column<float>(type: "real", nullable: false),
                    Temp = table.Column<float>(type: "real", nullable: false),
                    SolarRad = table.Column<float>(type: "real", nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pop = table.Column<int>(type: "integer", nullable: false),
                    AppTemp = table.Column<float>(type: "real", nullable: false),
                    CloudsLow = table.Column<int>(type: "integer", nullable: false),
                    TimestampLocal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CloudsMid = table.Column<int>(type: "integer", nullable: false),
                    Precip = table.Column<int>(type: "integer", nullable: false),
                    WeatherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoints", x => x.DId);
                    table.ForeignKey(
                        name: "FK_DataPoints_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "WId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_WeatherId",
                table: "DataPoints",
                column: "WeatherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPoints");

            migrationBuilder.DropTable(
                name: "Weathers");

        }
    }
}
