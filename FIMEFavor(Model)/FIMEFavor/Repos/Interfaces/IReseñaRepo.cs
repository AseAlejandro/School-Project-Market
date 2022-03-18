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
    public interface IReseñaRepo : IRepo<Reseña>
    {
        IEnumerable<Reseña> GetReseñasCuenta(int cuentaid);
    }
}
