using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class nullableWindCdirFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
            name: "WindDir",
            table: "DataPoints",
            type: "real",
            nullable: true,
            oldClrType: typeof(float),
            oldType: "real",
            oldNullable: false);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
            name: "WindDir",
            table: "DataPoints",
            type: "real",
            nullable: false,
            oldClrType: typeof(float),
            oldType: "real",
            oldNullable: false);

        }
    }
}
