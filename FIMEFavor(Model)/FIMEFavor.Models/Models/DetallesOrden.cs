using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIMEFavor.Models.Models.Base;

namespace FIMEFavor.Models.Models
{
    [Table("DetallesOrdenes", Schema ="FIME")]
    public class DetallesOrden : EntityBase
    {
        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }

        public int OrdenId { get; set; }

        [ForeignKey(nameof(OrdenId))]
        public Orden Orden { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public decimal CostoTotal { get; set; }
    }
}
