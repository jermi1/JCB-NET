using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Estado_OS")]
    public class EstadoOrdenServicio
    {
        [Key]
        [Column(TypeName = "tinyint")]
        public int Id_EstadoOS { get; set; }

        [Required]
        [Column(TypeName = "varchar(22)")]
        public string NombreEstado { get; set; }
    }
}
