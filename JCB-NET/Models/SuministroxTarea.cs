using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Suministro_x_Tarea")]
    public class SuministroxTarea
    {
        [Key]
        public int Id_Suministro { get; set; }
        public Suministro Suministro { get; set; }

        [Key]
        public int Id_Tarea { get; set; }
        public Tarea Tarea { get; set; }
    }
}
