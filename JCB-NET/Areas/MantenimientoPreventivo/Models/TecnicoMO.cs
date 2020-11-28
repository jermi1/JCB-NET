using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Areas.MantenimientoPreventivo.Models
{
    public class TecnicoMO
    {
        public int Id_Tecnico { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Nro Documento Requerido")]
        public string NroDocumento { get; set; }

    }
}
