using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Plan_Mantenimiento_Preventivo")]
    public class PlanMantenimientoPreventivo
    {
        [Key]
        public int Id_PlanMantenimientoPreventivo { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string NombrePlan { get; set; }
        
        [Required]
        [Column(TypeName = "tinyint")]
        public int Id_EstadoPlan { get; set; }

        [ForeignKey("Id_EstadoPlan")]
        public virtual EstadoPlan EstadoPlan { get; set; }
        
        [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }

        [Required]
        public bool isCorrectivo { get; set; }

        public bool EnEjecucion { get; set; }
    }
}
