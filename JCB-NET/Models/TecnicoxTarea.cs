using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Tecnico_x_Tarea")]
    public class TecnicoxTarea
    {
        [Key]
        public int Id_Tecnico { get; set; }
        public Tecnico Tecnico { get; set; }

        [Key]
        public int Id_Tarea { get; set; }
        public Tarea Tarea { get; set; }
    }
}
