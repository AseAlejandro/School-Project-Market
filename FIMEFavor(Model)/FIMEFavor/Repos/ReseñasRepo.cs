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

namespace FIMEFavor.DAL.Repos.Interfaces
{
    public class ReseñasRepo : RepoBase<Reseña>, IReseñaRepo
    {
        public ReseñasRepo(DbContextOptions<FimeContext> options) : base(options)
        {

        }

        public ReseñasRepo()
        {

        }

        public override IEnumerable<Reseña> GetAll()
            => Table.OrderBy(x => x.CuentaId);

        public override IEnumerable<Reseña> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.CuentaId), skip, take);

        public IEnumerable<Reseña> GetReseñasCuenta(int cuentaId)
            => Table.Where(x => x.CuentaId == cuentaId);
    }
}
