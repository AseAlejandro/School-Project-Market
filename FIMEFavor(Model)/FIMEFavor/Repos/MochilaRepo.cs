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
using Microsoft.Data.SqlClient;

namespace FIMEFavor.DAL.Repos
{
    public class MochilaRepo : RepoBase<Mochila>, IMochilaRepo
    {
        private readonly IProductoRepo _productoRepo;

        public MochilaRepo(DbContextOptions<FimeContext> options, IProductoRepo productoRepo) : base(options)
        {
            _productoRepo = productoRepo;
        }

        public MochilaRepo (IProductoRepo productoRepo) : base()
        {
            _productoRepo = productoRepo;
        }

        public override IEnumerable<Mochila> GetAll()
           => Table.OrderByDescending(x => x.FechaCreacion);
        public override IEnumerable<Mochila> GetRange(int skip, int take)
            => GetRange(Table.OrderByDescending(x => x.FechaCreacion), skip, take);

        public Mochila Find(int customerId, int productId)
        {
            return Table.FirstOrDefault(x => x.CuentaId == customerId && x.ProductoId == productId);
        }

        public override int Update(Mochila entity, bool persist = true)
        {
            return Update(entity, _productoRepo.Find(entity.ProductoId)?.Existencia, persist);
        }

        public int Update(Mochila entity, int? quantityInStock, bool persist = true)
        {
            if (entity.Cantidad <= 0)
            {
                return Delete(entity, persist);
            }
            if (entity.Cantidad > quantityInStock)
            {

            }
            return base.Update(entity, persist);
        }

        public override int Add(Mochila entity, bool persist = true)
        {
            return Add(entity, _productoRepo.Find(entity.ProductoId)?.Existencia, persist);

        }
        public int Add(Mochila entity, int? quantityInStock, bool persist = true)
        {
            var item = Find(entity.CuentaId, entity.ProductoId);
            if (item == null)
            {
                if (quantityInStock != null && entity.Cantidad > quantityInStock.Value)
                {

                }
                return base.Add(entity, persist);
            }
            item.Cantidad += entity.Cantidad;
            return item.Cantidad <= 0 ? Delete(item, persist) : Update(item, quantityInStock, persist);
        }

        internal static MochilaConInfoProducto GetRecord(int customerId, Mochila scr, Producto p, Categoria c)
            => new MochilaConInfoProducto
            {
                Id = scr.Id,
                Fecha = scr.FechaCreacion,
                ClienteId = customerId,
                Cantidad = scr.Cantidad,
                ProductoId = scr.ProductoId,
                Descripcion = p.Descripcion,
                Nombre = p.Nombre,
                Modelo = p.Modelo,
                Imagen = p.Imagen,
                Precio = p.Precio,
                Existencia = p.Existencia,
                CategoriaNombre = c.CategoriaNombre,
                CostoTotal = scr.CostoTotal
            };
        public MochilaConInfoProducto GetShoppingCartRecord(
            int customerId, int productId)
            => Table
            .Where(x => x.CuentaId == customerId && x.ProductoId == productId)
            .Include(x => x.Producto)
            .ThenInclude(p => p.Categoria)
            .Select(x => GetRecord(customerId, x, x.Producto, x.Producto.Categoria))
            .FirstOrDefault();

        public IQueryable<MochilaConInfoProducto> GetShoppingCartRecords(
            int customerId)
            => Table
            .Where(x => x.CuentaId == customerId)
            .Include(x => x.Producto)
            .ThenInclude(p => p.Categoria)
            .Select(x => GetRecord(customerId, x, x.Producto, x.Producto.Categoria));


        public int Ordenar(int clienteId, string lugarDeEntrega, string comentarios, string metodoDePago)
        {
            try
            {
                Context.Database.ExecuteSqlRaw(
                $"EXEC [FIME].[ComprarItemsEnMochila] {clienteId}, 1, {lugarDeEntrega}, {comentarios}, {metodoDePago}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
            return clienteId;
        }
    }
}
