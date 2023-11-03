using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleQueries.Migrations
{
    public partial class enumMigrationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "user");
        }
    }
}
