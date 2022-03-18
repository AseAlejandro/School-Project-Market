using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIMEFavor.DAL.Repos.Base;
using FIMEFavor.Models.Models;
using FIMEFavor.Models.ViewModels;

namespace FIMEFavor.DAL.Repos.Interfaces
{
    public interface IOrdenRepo : IRepo<Orden>
    {
        IEnumerable<Orden> GetOrdenHistory(int cuentaId);
        OrdenConDetallesAndInfoProducto GetOneWithDetails(int ordenId);
        IQueryable<Orden> GetOrdenesRepartidor(int repartidorId);
        IQueryable<Orden> GetOrdenesSinRepartidor();
        IQueryable<Orden> GetJustOne(int id);
    }
}
