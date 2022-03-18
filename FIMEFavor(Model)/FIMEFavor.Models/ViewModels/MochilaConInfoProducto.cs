using FIMEFavor.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMEFavor.Models.ViewModels
{
    public class MochilaConInfoProducto : ProductoYCategoriaBase
    {

        public DateTime Fecha { get; set; }
        public int? ClienteId { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
