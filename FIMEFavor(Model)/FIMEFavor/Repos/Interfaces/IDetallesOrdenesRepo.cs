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
    public interface IDetallesOrdenesRepo : IRepo<DetallesOrden>
    {
        IEnumerable<DetallesOrdenConInfoProducto> GetCustomersOrdersWithDetails(int cuentaId);
        IEnumerable<DetallesOrdenConInfoProducto> GetSingleOrderWithDetails(int ordenId);
    }
}
