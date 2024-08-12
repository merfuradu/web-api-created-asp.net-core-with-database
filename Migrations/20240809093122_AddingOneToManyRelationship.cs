using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_week1.Migrations
{
    /// <inheritdoc />
    public partial class AddingOneToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_Addresses_AddressId",
                table: "PersonalData");

            migrationBuilder.DropIndex(
                name: "IX_PersonalData_AddressId",
                table: "PersonalData");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "PersonalData");

            migrationBuilder.AddColumn<List<int>>(
                name: "AddressIds",
                table: "PersonalData",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressIds",
                table: "PersonalData");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "PersonalData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_AddressId",
                table: "PersonalData",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_Addresses_AddressId",
                table: "PersonalData",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
