using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class ChangesWithModelBuilder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                schema: "FIME",
                table: "Productos",
                type: "money",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                schema: "FIME",
                table: "Mochila",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                schema: "FIME",
                table: "Mochila",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                schema: "FIME",
                table: "Mochila",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostoTotal",
                schema: "FIME",
                table: "Mochila",
                type: "money",
                nullable: false,
                computedColumnSql: "[Cantidad]*[Precio]",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                schema: "FIME",
                table: "Productos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                schema: "FIME",
                table: "Mochila",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                schema: "FIME",
                table: "Mochila",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostoTotal",
                schema: "FIME",
                table: "Mochila",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldComputedColumnSql: "[Cantidad]*[Precio]");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                schema: "FIME",
                table: "Mochila",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }
    }
}
