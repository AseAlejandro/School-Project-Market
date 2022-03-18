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
    [Table("Cuentas", Schema ="FIME")]
    public class Cuentas : EntityBase
    {
        public int Matricula { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

    }
}
