using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIDs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WId",
                table: "Weathers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DId",
                table: "DataPoints",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Weathers",
                newName: "WId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DataPoints",
                newName: "DId");
        }
    }
}
