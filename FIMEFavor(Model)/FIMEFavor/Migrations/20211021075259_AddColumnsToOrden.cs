using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class AddColumnsToOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                schema: "FIME",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetodoDePago",
                schema: "FIME",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                schema: "FIME",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "MetodoDePago",
                schema: "FIME",
                table: "Ordenes");
        }
    }
}
