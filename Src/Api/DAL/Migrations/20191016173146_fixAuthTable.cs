using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fixAuthTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorizedUsers",
                table: "AuthorizedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AuthorizedUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AuthorizedUsers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorizedUsers",
                table: "AuthorizedUsers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorizedUsers",
                table: "AuthorizedUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorizedUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AuthorizedUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorizedUsers",
                table: "AuthorizedUsers",
                column: "Email");
        }
    }
}
