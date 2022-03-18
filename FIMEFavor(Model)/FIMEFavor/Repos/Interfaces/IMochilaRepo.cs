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
    public interface IMochilaRepo : IRepo<Mochila>
    {
        MochilaConInfoProducto GetShoppingCartRecord(int customerId, int productId);
        IQueryable<MochilaConInfoProducto> GetShoppingCartRecords(int customerId);
        int Ordenar(int clienteId, string lugarDeEntrega, string comentarios, string metodoDePago);
        Mochila Find(int customerId, int productId);
        int Update(Mochila entity, int? quantityInStock, bool persist = true);
        int Add(Mochila entity, int? quantityInStock, bool persist = true);
    }
}
