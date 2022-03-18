using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class AssignGetOrdenTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                schema: "FIME",
                table: "Ordenes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                schema: "FIME",
                table: "Ordenes",
                type: "money",
                nullable: false,
                computedColumnSql: "FIME.GetOrdenTotal([Id])",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                schema: "FIME",
                table: "Ordenes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldComputedColumnSql: "FIME.GetOrdenTotal([Id])");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                schema: "FIME",
                table: "Ordenes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");
        }
    }
}
