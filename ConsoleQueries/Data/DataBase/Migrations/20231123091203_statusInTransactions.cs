using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleQueries.Migrations
{
    /// <inheritdoc />
    public partial class statusInTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "order_transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "order_transactions");
        }
    }
}
