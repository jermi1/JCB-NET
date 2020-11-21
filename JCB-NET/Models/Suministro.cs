using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Suministro")]
    public class Suministro
    {
        [Key]   
        public int Id_Suministro { get; set; }
        
        [Required]
        [Column(TypeName = "smallint")]
        public int Id_Bodega { get; set; }

        [ForeignKey("Id_Bodega")]
        public virtual Bodega Bodega { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Codigo { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string StockMinimo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Unidades { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Proveedor { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }

        public IList<SuministroxTarea> SuministroxTareas { get; set; }
    }
}
