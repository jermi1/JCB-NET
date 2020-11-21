using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Tecnico")]
    public class Tecnico
    {
        [Key]
        public int Id_Tecnico { get; set; }

        [Required]
        [Column(TypeName = "varchar(18)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string ApePaterno { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string ApeMaterno { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Direccion { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Telefono { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string NroDocumento { get; set; }

        public IList<TecnicoxTarea> TecnicoxTareas { get; set; }
    }
}
