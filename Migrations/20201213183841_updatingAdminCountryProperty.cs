using Microsoft.EntityFrameworkCore.Migrations;

namespace buddy_up.Migrations
{
    public partial class updatingAdminCountryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Country_CountryID",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Admin",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_CountryID",
                table: "Admin",
                newName: "IX_Admin_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Country_CountryId",
                table: "Admin",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Country_CountryId",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Admin",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_CountryId",
                table: "Admin",
                newName: "IX_Admin_CountryID");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "Admin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Country_CountryID",
                table: "Admin",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
