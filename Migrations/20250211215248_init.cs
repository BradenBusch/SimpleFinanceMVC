using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleFinance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountDetail",
                columns: table => new
                {
                    AccountDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDetail", x => x.AccountDetailId);
                });

            migrationBuilder.CreateTable(
                name: "AccountHeader",
                columns: table => new
                {
                    AccountHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHeader", x => x.AccountHeaderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDetail");

            migrationBuilder.DropTable(
                name: "AccountHeader");
        }
    }
}
