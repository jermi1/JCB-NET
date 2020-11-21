using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Orden_Servicio")]
    public class OrdenServicio
    {
        [Key]
        public int Id_Orden_Servicio{ get; set; }

        [Required]
        public int Id_Tarea { get; set; }

        [ForeignKey("Id_Tarea")]
        public virtual Tarea Tarea { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string CodigoOS { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string TipoMantenimiento { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaAtencion{ get; set; }
        
        [Column(TypeName = "varchar(20)")]
        public string ResultadoAtencion { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public int Id_EstadoOS { get; set; }

        [ForeignKey("Id_EstadoOS")]
        public virtual EstadoOrdenServicio EstadoOrdenServicio { get; set; }
    }
}
