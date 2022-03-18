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
using FIMEFavor.Models.ViewModels.Base;


namespace FIMEFavor.DAL.Repos
{
    public class OrdenRepo : RepoBase<Orden>, IOrdenRepo
    {
        private readonly IDetallesOrdenesRepo _detallesOrdenesRepo;

        public OrdenRepo (DbContextOptions<FimeContext> options, IDetallesOrdenesRepo detallesOrdenesRepo) : base(options)
        {
            _detallesOrdenesRepo = detallesOrdenesRepo;
        }

        public OrdenRepo(IDetallesOrdenesRepo detallesOrdenesRepo)
        {
            _detallesOrdenesRepo = detallesOrdenesRepo;
        }

        public override IEnumerable<Orden> GetAll()
            => Table.OrderByDescending(x => x.Fecha);

        public IQueryable<Orden> GetJustOne(int id)
            => Table
                .Where(x=>x.Id == id)
                .Select(x => new Orden
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    RepartidorId = x.RepartidorId,
                    ClienteId = x.ClienteId,
                    LugarDeEntrega = x.LugarDeEntrega,
                    Comentarios = x.Comentarios,
                    Total = x.Total,
                    MetodoDePago = x.MetodoDePago,
                    Cuenta = x.Cuenta
                });

        public override IEnumerable<Orden> GetRange(int skip, int take)
            => GetRange(Table.OrderByDescending(x => x.Fecha), skip, take);

        public IEnumerable<Orden> GetOrdenHistory(int cuentaId)
            => Table.Where(x => x.Id == cuentaId)
                .Select(x => new Orden
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    ClienteId = cuentaId,
                    Total = x.Total
                });

        public OrdenConDetallesAndInfoProducto GetOneWithDetails(int orderId)
            => Table
                .Where(x => x.Id == orderId)
                .Select(x => new OrdenConDetallesAndInfoProducto
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    Total = x.Total,
                    OrderDetails = _detallesOrdenesRepo.GetSingleOrderWithDetails(orderId).ToList()
                })
            .FirstOrDefault();

        public IQueryable<Orden> GetOrdenesRepartidor(int repartidorId)
            => Table
                .Where(x => x.RepartidorId == repartidorId)
                .Select(x => new Orden
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    RepartidorId = x.RepartidorId,
                    ClienteId = x.ClienteId,
                    LugarDeEntrega = x.LugarDeEntrega,
                    Comentarios = x.Comentarios,
                    Total = x.Total,
                    MetodoDePago = x.MetodoDePago,
                    Cuenta = x.Cuenta
                });
                    

        public IQueryable<Orden> GetOrdenesSinRepartidor()
            => Table
                .Where(x => x.RepartidorId == null)
                .Select(x => new Orden
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    RepartidorId = x.RepartidorId,
                    ClienteId = x.ClienteId,
                    LugarDeEntrega = x.LugarDeEntrega,
                    Comentarios = x.Comentarios,
                    Total = x.Total,
                    MetodoDePago = x.MetodoDePago,
                    Cuenta = x.Cuenta
                });
    }
}
