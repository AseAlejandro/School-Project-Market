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
using FIMEFavor.Models.ViewModels.Base;

namespace FIMEFavor.DAL.Repos
{
    public class ProductoRepo : RepoBase<Producto>, IProductoRepo
    {
        public ProductoRepo(DbContextOptions<FimeContext> options) : base(options)
        {

        }

        public ProductoRepo() : base()
        {

        }

        public override IEnumerable<Producto> GetAll()
            => Table.OrderBy(x => x.Nombre);
        public override IEnumerable<Producto> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.Nombre), skip, take);


        internal static ProductoYCategoriaBase GetRecord(Producto p, Categoria c)
            => new ProductoYCategoriaBase()
            {
                CategoriaNombre = c.CategoriaNombre,
                CategoriaId = p.CategoriaId,
                Precio = p.Precio,
                Descripcion = p.Descripcion,
                Id = p.Id,
                Nombre = p.Nombre,
                Modelo = p.Modelo,
                Imagen = p.Imagen,
                Existencia = p.Existencia,
                VendedorId = p.VendedorId
            };

        public IQueryable<ProductoYCategoriaBase> GetProductsForCategory(int id)
            => Table
                .Where(p => p.CategoriaId == id)
                .Include(p => p.Categoria)
                .Select(item => GetRecord(item, item.Categoria));

        public IQueryable<ProductoYCategoriaBase> GetAllOneVendedor(int id)
            => Table
                .Where(x => x.VendedorId == id)
                .Include(p => p.Categoria)
                .Select(item => GetRecord(item, item.Categoria));


        public IQueryable<ProductoYCategoriaBase> GetAllWithCategoryName()
            => Table
                .Include(p => p.Categoria)
                .Select(item => GetRecord(item, item.Categoria));
                


        public ProductoYCategoriaBase GetOneWithCategoryName(int id)
            => Table
                .Where(p => p.Id == id)
                .Include(p => p.Categoria)
                .Select(item => GetRecord(item, item.Categoria))
                .SingleOrDefault();

        public IQueryable<ProductoYCategoriaBase> Search(string searchString)
            => Table
                .Where(p =>
                    p.Descripcion.ToLower().Contains(searchString.ToLower())
                    || p.Nombre.ToLower().Contains(searchString.ToLower()))
                .Include(p => p.Categoria)
                .Select(item => GetRecord(item, item.Categoria));
    }
}
