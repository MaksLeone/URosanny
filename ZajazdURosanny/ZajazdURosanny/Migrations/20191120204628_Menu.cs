using Microsoft.EntityFrameworkCore.Migrations;

namespace ZajazdURosanny.Migrations
{
    public partial class Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Menu",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menu",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menu");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Menu",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
