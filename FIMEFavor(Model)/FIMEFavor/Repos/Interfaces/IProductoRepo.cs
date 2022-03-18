using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIMEFavor.DAL.Repos.Base;
using FIMEFavor.Models.Models;
using FIMEFavor.Models.ViewModels.Base;


namespace FIMEFavor.DAL.Repos.Interfaces
{
    public interface IProductoRepo : IRepo<Producto>
    {
        IQueryable<ProductoYCategoriaBase> Search(string searchString);
        IQueryable<ProductoYCategoriaBase> GetAllWithCategoryName();
        IQueryable<ProductoYCategoriaBase> GetProductsForCategory(int id);
        ProductoYCategoriaBase GetOneWithCategoryName(int id);
        IQueryable<ProductoYCategoriaBase> GetAllOneVendedor(int id);
    }
}
