using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleFinance.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseHeaderAddName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseName",
                table: "ExpenseHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseName",
                table: "ExpenseHeader");
        }
    }
}
