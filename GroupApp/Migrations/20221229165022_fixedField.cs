using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupApp.Migrations
{
    /// <inheritdoc />
    public partial class fixedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Adresses_AdressId",
                table: "Clubs");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Clubs",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_AdressId",
                table: "Clubs",
                newName: "IX_Clubs_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Adresses_AddressId",
                table: "Clubs",
                column: "AddressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Adresses_AddressId",
                table: "Clubs");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Clubs",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_AddressId",
                table: "Clubs",
                newName: "IX_Clubs_AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Adresses_AdressId",
                table: "Clubs",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
