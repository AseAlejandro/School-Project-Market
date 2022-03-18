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
    [Table("Mochila", Schema = "FIME")]
    public class Mochila : EntityBase
    {
        public DateTime FechaCreacion { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public decimal CostoTotal { get; set; }

        public int CuentaId { get; set; }

        [ForeignKey(nameof(CuentaId))]
        public Cuentas Cuentas { get; set; }
    }
}
