using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class ChangingToICollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressIds",
                table: "PersonalData");

            migrationBuilder.AddColumn<int>(
                name: "PersonalDataId",
                table: "Addresses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonalDataId",
                table: "Addresses",
                column: "PersonalDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PersonalData_PersonalDataId",
                table: "Addresses",
                column: "PersonalDataId",
                principalTable: "PersonalData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PersonalData_PersonalDataId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PersonalDataId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PersonalDataId",
                table: "Addresses");

            migrationBuilder.AddColumn<List<int>>(
                name: "AddressIds",
                table: "PersonalData",
                type: "integer[]",
                nullable: true);
        }
    }
}
