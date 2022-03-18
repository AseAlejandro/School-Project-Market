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
    [Table("Productos", Schema ="FIME")]
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }

        public string Modelo { get; set; }

        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public decimal Precio { get; set; }

        public int Existencia { get; set; }

        public int VendedorId { get; set; }

        [ForeignKey(nameof(VendedorId))]
        public Cuentas Cuentas { get; set; }
    }
}
