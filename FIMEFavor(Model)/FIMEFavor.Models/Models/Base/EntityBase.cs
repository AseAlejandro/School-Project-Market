using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIMEFavor.Models.Models.Base
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
