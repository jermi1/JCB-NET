using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Tarea")]
    public class Tarea
    {
        [Key]
        public int Id_Tarea { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Nombre { get; set; }
        
        [Column(TypeName = "varchar(15)")]
        public string Clasificacion { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Prioridad { get; set; }
        public int DuracionEstimada { get; set; }
        public int TiempoPara { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string Falla { get; set; }
        
        [Column(TypeName = "varchar(250)")]
        public string Descripcion { get; set; }
        
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime FechaInicio { get; set; } //si es correctiva es la fecha de creacion
        public DateTime FechaFin { get; set; }
       
        [Required]
        public int Id_PlanMantenimientoPreventivo { get; set; }

        [ForeignKey("Id_PlanMantenimientoPreventivo")]
        public virtual PlanMantenimientoPreventivo PlanMantenimientoPreventivo { get; set; }
        
        [Required]
        [Column(TypeName = "tinyint")]
        public int Id_Periodicidad { get; set; }
        
        [ForeignKey("Id_Periodicidad")]
        public virtual Periodicidad Periodicidad { get; set; }

        [Required]
        public int Id_Maquina { get; set; }

        [ForeignKey("Id_Maquina")]
        public virtual Maquina Maquina { get; set; }
        
        public IList<SuministroxTarea> SuministroxTareas { get; set; }
        
        public IList<TecnicoxTarea> TecnicoxTareas { get; set; }
    }
}
