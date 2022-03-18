using FIMEFavor.Models.ViewModels.Base;
using FIMEFavor.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMEFavor.Models.ViewModels
{
    public class DetallesOrdenConInfoProducto : ProductoYCategoriaBase
    {
        public int OrdenId { get; set; }

        public int Cantidad { get; set; }

        public decimal CostoTotal { get; set; }

        public string Comentarios { get; set; }

        public string MetodoDePago { get; set; }
    }
}
