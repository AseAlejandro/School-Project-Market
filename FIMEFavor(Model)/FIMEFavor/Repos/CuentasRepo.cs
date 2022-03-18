using FIMEFavor.DAL.Repos.Base;
using FIMEFavor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FIMEFavor.DAL.EF;
using FIMEFavor.DAL.Repos.Interfaces;

namespace FIMEFavor.DAL.Repos
{
    public class CuentasRepo : RepoBase<Cuentas>, ICuentasRepo
    {
        public CuentasRepo(DbContextOptions<FimeContext> options) : base(options)
        {

        }

        public CuentasRepo()
        {

        }

        internal static Cuentas GetCuentas(Cuentas c)
            => new Cuentas()
            {
                Id = c.Id,
                Correo = c.Correo,
                Matricula = c.Matricula,
                Nombre = c.Nombre,
                Contrasena = c.Contrasena
            };

        public override IEnumerable<Cuentas> GetAll()
            => Table.OrderBy(x => x.Id);

        public override IEnumerable<Cuentas> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.Id), skip, take);

        public IQueryable<Cuentas> GetCuenta(string correo)
            => Table
                .Where(p =>
                   p.Correo.ToLower() == correo.ToLower())
                .Select(item => GetCuentas(item));
    }
}
