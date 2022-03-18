using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class makeNullableRepartidorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Cuentas_RepartidorId",
                schema: "FIME",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "RepartidorId",
                schema: "FIME",
                table: "Ordenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Cuentas_RepartidorId",
                schema: "FIME",
                table: "Ordenes",
                column: "RepartidorId",
                principalSchema: "FIME",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Cuentas_RepartidorId",
                schema: "FIME",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "RepartidorId",
                schema: "FIME",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Cuentas_RepartidorId",
                schema: "FIME",
                table: "Ordenes",
                column: "RepartidorId",
                principalSchema: "FIME",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
