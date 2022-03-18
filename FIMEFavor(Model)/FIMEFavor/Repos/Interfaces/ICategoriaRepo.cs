using FIMEFavor.DAL.Repos.Base;
using FIMEFavor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMEFavor.DAL.Repos.Interfaces
{
    public interface ICategoriaRepo : IRepo<Categoria>
    {
        IEnumerable<Categoria> GetAllWithProducts();
        Categoria GetOneWithProducts(int? id);
    }
}
