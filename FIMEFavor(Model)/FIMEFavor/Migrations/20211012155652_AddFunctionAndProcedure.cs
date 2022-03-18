using Microsoft.EntityFrameworkCore.Migrations;

namespace FIMEFavor.DAL.Migrations
{
    public partial class AddFunctionAndProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = "CREATE FUNCTION FIME.GetOrdenTotal ( @OrdenId INT ) " +
                 "RETURNS MONEY WITH SCHEMABINDING " +
                 "BEGIN " +
                 "DECLARE @Result MONEY; " +
                 "SELECT @Result = SUM([Cantidad]*[Precio]) FROM FIME.DetallesOrdenes" +
                 " WHERE OrdenId = @OrdenId; RETURN @Result END";
            migrationBuilder.Sql(sql);


            sql = "CREATE PROCEDURE [FIME].[ComprarItemsEnMochila] " +
                " (@clienteId INT = 0, @ordenId INT OUTPUT, @lugarDeEntrega nvarchar(50), @comentarios nvarchar(100), @metodoDePago nvarchar(50)) AS BEGIN " +
                " SET NOCOUNT ON; " +
                " INSERT INTO FIME.Ordenes (ClienteId, Fecha, LugarDeEntrega, Comentarios, MetodoDePago) " +
                " VALUES(@clienteId, GETDATE(), @lugarDeEntrega, @comentarios, @metodoDePago); " +
                " SET @ordenId = SCOPE_IDENTITY(); " +
                " DECLARE @TranName VARCHAR(20);SELECT @TranName = 'CommitOrder'; " +
                " BEGIN TRANSACTION @TranName; " +
                " BEGIN TRY " +
                " INSERT INTO FIME.DetallesOrdenes (OrdenId, ProductoId, Cantidad, Precio) " +
                " SELECT @ordenId, ProductoId, Cantidad, p.Precio" +
                " FROM FIME.Mochilas scr " +
                " INNER JOIN FIME.Productos p ON p.Id = scr.ProductoId " +
                " WHERE ClienteId = @clienteId; " +
                " DELETE FROM FIME.Mochilas WHERE ClienteId = @clienteId; " +
                " COMMIT TRANSACTION @TranName; " +
                " END TRY " +
                " BEGIN CATCH " +
                " ROLLBACK TRANSACTION @TranName; " +
                " SET @ordenId = -1; " +
                " END CATCH; " +
                " END;";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION FIME.GetOrdenTotal");
            migrationBuilder.Sql("DROP PROCEDURE [FIME].[ComprarItemsEnMochila]");
        }
    }
}
