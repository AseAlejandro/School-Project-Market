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
    public class Reseña : EntityBase
    {
        public string Descripcion { get; set; }

        public int CuentaId { get; set; }

        public Cuentas Cuentas { get; set; }

        public int Calificacion { get; set; }
    }
}
