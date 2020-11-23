using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Maquina")]
    public class Maquina
    {
        [Key]
        public int Id_Maquina { get; set; }

        [Required]
        [Column(TypeName = "varchar(18)")]
        public string Codigo { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Ubicacion { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Tamano { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Peso { get; set; }
        // crear columna Zona

        [Column(TypeName = "varchar(25)")]
        public string Zona { get; set; }
    }
}
