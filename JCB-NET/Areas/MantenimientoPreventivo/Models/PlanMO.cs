using JCB_NET.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace JCB_NET.Areas.MantenimientoPreventivo.Models
{
    public class PlanMO
    {
        public int Id_PlanMantenimientoPreventivo { get; set; }

        [Required(ErrorMessage = "Seleccione el nombre del Plan")]
        [MinLength(3, ErrorMessage = "La longitud minima es 3")]
        [MaxLength(15, ErrorMessage = "La longitud maxima es 15")]
        [Display(Name = "Nombre Plan")]
        [DisplayName("Nombre Plan")]
        public string NombrePlan { get; set; }

        [Display(Name = "Estado")]
        [DisplayName("Estado")]
        public string nombreEstado { get; set; }

        //Agregar
        [Required(ErrorMessage = "Seleccione Estado")]
        public int? Id_EstadoPlan { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DisplayName("Fecha Creacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }

        public bool isCorrectivo { get; set; }

        public bool EnEjecucion { get; set; }
    }
}
