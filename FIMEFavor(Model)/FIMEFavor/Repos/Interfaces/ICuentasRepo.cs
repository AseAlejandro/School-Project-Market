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
    public interface ICuentasRepo : IRepo<Cuentas>
    {
        IQueryable<Cuentas> GetCuenta(string correo);
    }
}
