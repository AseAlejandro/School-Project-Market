using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                schema: "FIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                schema: "FIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LugarDeEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepartidorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Cuentas_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "FIME",
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Cuentas_RepartidorId",
                        column: x => x.RepartidorId,
                        principalSchema: "FIME",
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reseñas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    CuentasId = table.Column<int>(type: "int", nullable: true),
                    Calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reseñas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reseñas_Cuentas_CuentasId",
                        column: x => x.CuentasId,
                        principalSchema: "FIME",
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "FIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "FIME",
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Cuentas_VendedorId",
                        column: x => x.VendedorId,
                        principalSchema: "FIME",
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesOrdenes",
                schema: "FIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrdenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalSchema: "FIME",
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "FIME",
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Mochila",
                schema: "FIME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mochila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mochila_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "FIME",
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mochila_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "FIME",
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_OrdenId",
                schema: "FIME",
                table: "DetallesOrdenes",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_ProductoId",
                schema: "FIME",
                table: "DetallesOrdenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mochila_CuentaId",
                schema: "FIME",
                table: "Mochila",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mochila_ProductoId",
                schema: "FIME",
                table: "Mochila",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId",
                schema: "FIME",
                table: "Ordenes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_RepartidorId",
                schema: "FIME",
                table: "Ordenes",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                schema: "FIME",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VendedorId",
                schema: "FIME",
                table: "Productos",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_CuentasId",
                table: "Reseñas",
                column: "CuentasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesOrdenes",
                schema: "FIME");

            migrationBuilder.DropTable(
                name: "Mochila",
                schema: "FIME");

            migrationBuilder.DropTable(
                name: "Reseñas");

            migrationBuilder.DropTable(
                name: "Ordenes",
                schema: "FIME");

            migrationBuilder.DropTable(
                name: "Productos",
                schema: "FIME");

            migrationBuilder.DropTable(
                name: "Categorias",
                schema: "FIME");
        }
    }
}
