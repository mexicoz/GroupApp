using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupApp.Migrations
{
    /// <inheritdoc />
    public partial class changedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Adresses_AdressId",
                table: "Races");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Races",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Races_AdressId",
                table: "Races",
                newName: "IX_Races_AddressId");

            migrationBuilder.RenameColumn(
                name: "Sity",
                table: "Adresses",
                newName: "City");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Adresses_AddressId",
                table: "Races",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Adresses_AddressId",
                table: "Races");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Races",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Races_AddressId",
                table: "Races",
                newName: "IX_Races_AdressId");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Adresses",
                newName: "Sity");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Adresses_AdressId",
                table: "Races",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
