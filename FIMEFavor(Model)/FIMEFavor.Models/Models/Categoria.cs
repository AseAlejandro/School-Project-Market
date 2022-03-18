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
    [Table("Categorias", Schema ="FIME")]
    public class Categoria : EntityBase
    {
        public string CategoriaNombre { get; set; }

        [InverseProperty(nameof(Producto.Categoria))]
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
