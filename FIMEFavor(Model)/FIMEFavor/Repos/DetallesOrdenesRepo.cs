using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIMEFavor.DAL.EF;
using FIMEFavor.DAL.Repos.Base;
using FIMEFavor.DAL.Repos.Interfaces;
using FIMEFavor.Models.Models;
using Microsoft.EntityFrameworkCore;
using FIMEFavor.Models.ViewModels;

namespace FIMEFavor.DAL.Repos
{
    public class DetallesOrdenesRepo : RepoBase<DetallesOrden>, IDetallesOrdenesRepo
    {
        public DetallesOrdenesRepo(DbContextOptions<FimeContext> options) : base(options)
        {

        }
        public DetallesOrdenesRepo()
        {

        }

        public override IEnumerable<DetallesOrden> GetAll()
            => Table.OrderBy(x => x.Id);

        public override IEnumerable<DetallesOrden> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.Id), skip, take);

        internal IEnumerable<DetallesOrdenConInfoProducto> GetRecords(IQueryable<DetallesOrden> query)
            => query
                .Include(x => x.Producto)
                .ThenInclude(p => p.Categoria)
                .Select(x => new DetallesOrdenConInfoProducto
                {
                    OrdenId = x.OrdenId,
                    Id = x.ProductoId,
                    Cantidad = x.Cantidad,
                    Precio = x.Precio,
                    CostoTotal = x.CostoTotal,
                    Descripcion = x.Producto.Descripcion,
                    Nombre = x.Producto.Nombre,
                    Imagen = x.Producto.Imagen,
                    Modelo = x.Producto.Modelo,
                    CategoriaNombre = x.Producto.Categoria.CategoriaNombre
                })
                .OrderBy(x => x.Nombre);

        public IEnumerable<DetallesOrdenConInfoProducto> GetCustomersOrdersWithDetails(int customerId)
            => GetRecords(Table.Where(x => x.Orden.ClienteId == customerId));

        public IEnumerable<DetallesOrdenConInfoProducto> GetSingleOrderWithDetails(int orderId)
            => GetRecords(Table.Where(x => x.Orden.Id == orderId));
    }
}
