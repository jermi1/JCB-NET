using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Areas.MantenimientoPreventivo.Models
{
    public class SuministroMO
    {
        public int Id_Suministro { get; set; }

        [Required(ErrorMessage = "Seleccione Estado")]
        //public int Id_Bodega { get; set; }

        //[Required(ErrorMessage = "Seleccione Estado")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Seleccione Estado")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Seleccione Estado")]
        //public string StockMinimo { get; set; }

        //[Required(ErrorMessage = "Seleccione Estado")]
        public int Cantidad { get; set; }

        public string Unidades { get; set; }

        public string Proveedor { get; set; }

        //[Required]
        //public string Descripcion { get; set; }
    }
}
