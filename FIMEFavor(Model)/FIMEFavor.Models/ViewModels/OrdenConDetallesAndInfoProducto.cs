using FIMEFavor.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMEFavor.Models.ViewModels
{
    public class OrdenConDetallesAndInfoProducto : EntityBase
    {
        public int ClienteId { get; set; }

        public decimal Total { get; set; }

        public DateTime Fecha { get; set; }

        public IList<DetallesOrdenConInfoProducto> OrderDetails { get; set; }

        public string Comentarios { get; set; }

        public string MetodoDePago { get; set; }
    }
}
