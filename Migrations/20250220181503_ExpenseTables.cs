using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleFinance.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseDetail",
                columns: table => new
                {
                    ExpenseDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetail", x => x.ExpenseDetailId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseHeader",
                columns: table => new
                {
                    ExpenseHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseHeader", x => x.ExpenseHeaderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDetail");

            migrationBuilder.DropTable(
                name: "ExpenseHeader");
        }
    }
}
