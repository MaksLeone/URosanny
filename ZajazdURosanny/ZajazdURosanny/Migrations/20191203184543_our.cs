using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZajazdURosanny.Migrations
{
    public partial class our : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleViewModelId",
                table: "News",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_RoleViewModelId",
                table: "News",
                column: "RoleViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_RoleViewModel_RoleViewModelId",
                table: "News",
                column: "RoleViewModelId",
                principalTable: "RoleViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_RoleViewModel_RoleViewModelId",
                table: "News");

            migrationBuilder.DropTable(
                name: "RoleViewModel");

            migrationBuilder.DropIndex(
                name: "IX_News_RoleViewModelId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RoleViewModelId",
                table: "News");
        }
    }
}
