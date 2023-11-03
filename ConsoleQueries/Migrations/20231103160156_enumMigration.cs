using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleQueries.Migrations
{
    public partial class enumMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "order",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "order");
            
        }
    }
}
