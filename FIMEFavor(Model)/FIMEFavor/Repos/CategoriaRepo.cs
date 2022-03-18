using FIMEFavor.DAL.EF;
using FIMEFavor.DAL.Repos.Base;
using FIMEFavor.DAL.Repos.Interfaces;
using FIMEFavor.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FIMEFavor.DAL.Repos
{
    public class CategoriaRepo : RepoBase<Categoria>, ICategoriaRepo
    {
        public CategoriaRepo(DbContextOptions<FimeContext> options) : base(options)
        {

        }

        public CategoriaRepo()
        {

        }

        public override IEnumerable<Categoria> GetAll()
            => Table.OrderBy(x => x.CategoriaNombre);

        public override IEnumerable<Categoria> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.CategoriaNombre), skip, take);

        public Categoria GetOneWithProducts(int? id)
            => Table.Include(x => x.Productos).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Categoria> GetAllWithProducts()
            => Table.Include(x => x.Productos);
    }
}
