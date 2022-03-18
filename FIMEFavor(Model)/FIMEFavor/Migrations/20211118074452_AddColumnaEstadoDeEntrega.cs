using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class AddColumnaEstadoDeEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstadoDeEntrega",
                schema: "FIME",
                table: "Ordenes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoDeEntrega",
                schema: "FIME",
                table: "Ordenes");
        }
    }
}
