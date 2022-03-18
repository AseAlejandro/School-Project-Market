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
    [Table("Ordenes", Schema ="FIME")]
    public class Orden : EntityBase
    {
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cuentas Cuentas { get; set; }

        public decimal Total { get; set; }

        public string LugarDeEntrega { get; set; }

        public int? RepartidorId { get; set; }

        [ForeignKey(nameof(RepartidorId))]
        public Cuentas Cuenta { get; set; }

        [InverseProperty(nameof(DetallesOrden.Orden))]
        public List<DetallesOrden> DetallesOrdenes { get; set; } = new List<DetallesOrden>();

        public string Comentarios { get; set; }

        public string MetodoDePago { get; set; }

        public string? EstadoDeEntrega { get; set; }

    }
}
