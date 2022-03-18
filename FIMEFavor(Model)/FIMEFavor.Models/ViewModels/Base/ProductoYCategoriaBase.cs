using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIMEFavor.Models.Models.Base;

namespace FIMEFavor.Models.ViewModels.Base
{
    public class ProductoYCategoriaBase : EntityBase
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }

        public string Modelo { get; set; }

        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public decimal Precio { get; set; }

        public int Existencia { get; set; }

        public int VendedorId { get; set; }

        public string CategoriaNombre { get; set; }
    }
}
