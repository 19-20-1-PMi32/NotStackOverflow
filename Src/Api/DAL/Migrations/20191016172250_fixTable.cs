using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fixTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AuthorizedUsers_RefreshToken",
                table: "AuthorizedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AuthorizedUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizedUsers_RefreshToken",
                table: "AuthorizedUsers",
                column: "RefreshToken",
                unique: true,
                filter: "[RefreshToken] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthorizedUsers_RefreshToken",
                table: "AuthorizedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AuthorizedUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AuthorizedUsers_RefreshToken",
                table: "AuthorizedUsers",
                column: "RefreshToken");
        }
    }
}
