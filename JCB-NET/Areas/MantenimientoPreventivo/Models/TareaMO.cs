using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Areas.MantenimientoPreventivo.Models
{
    public class TareaMO
    {

        public int Id_Tarea { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la Tarea")]
        [Display(Name = "Nombre Tarea")]
        [DisplayName("Nombre Tarea")]
        [MinLength(3, ErrorMessage = "La longitud minima es 3")]
        [MaxLength(20, ErrorMessage = "La longitud maxima es 20")]
        public string Nombre { get; set; }

        [Display(Name = "Clasificación")]
        [DisplayName("Clasificación")]
        [MaxLength(15, ErrorMessage = "La longitud maxima es 15")]
        public string Clasificacion { get; set; }

        [Required]
        [Display(Name = "Prioridad")]
        [DisplayName("Prioridad")]
        public string Prioridad { get; set; }

        [Display(Name = "Duración Estimada")]
        [DisplayName("Duración Estimada")]
        public int DuracionEstimada { get; set; }

        [Display(Name = "Tiempo de Para")]
        [DisplayName("Tiempo de Para")]
        public int TiempoPara { get; set; }

        [Display(Name = "Falla")]
        [DisplayName("Falla")]
        public string Falla { get; set; }

        [Display(Name = "Descripción")]
        [DisplayName("Descripción")]
        [MaxLength(200, ErrorMessage = "La longitud maxima es 250")]
        public string Descripcion { get; set; }

        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Fecha Inicio")]
        [DisplayName("Fecha Inicio")]
        public DateTime FechaInicio { get; set; } //si es correctiva es la fecha de creacion

        [Display(Name = "Fecha Fin")]
        [DisplayName("Fecha Fin")]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Plan de Mantenimiento")]
        [DisplayName("Plan de Mantenimiento")]
        public string nombrePlan { get; set; }

        public int? Id_PlanMantenimientoPreventivo { get; set; }

        [Display(Name = "Periodicidad")]
        [DisplayName("Periodicidad")]
        public string Periodicidad { get; set; }

        [Required(ErrorMessage = "Seleccione la Periodicidad de la Tarea")]
        public int? Id_Periodicidad { get; set; }

        [Display(Name = "Codigo de Maquina")]
        [DisplayName("Codigo de Maquina")]
        public string CodigoMaquina { get; set; }

        [Required(ErrorMessage = "Seleccione el codigo de la maquina")]
        public int? Id_Maquina { get; set; }

        [Required(ErrorMessage = "Seleccione los suministros que se utilizaran")]
        public List<int> Suministros { get; set; }

        [Required(ErrorMessage = "Seleccione los técnicos para la tarea")]
        public List<int> Tecnicos { get; set; }

    }
}
