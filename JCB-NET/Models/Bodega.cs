using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Bodega")]
    public class Bodega
    {
        [Key]
        [Column(TypeName = "smallint")]
        public int Id_Bodega { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string NombreBodega { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }

    }
}
