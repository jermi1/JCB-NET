using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Tipo_Documento")]
    public class TipoDocumento
    {
        [Key]
        [Column(TypeName = "tinyint")]
        public int Id_TipoDocumento { get; set; }
       
        [Column(TypeName ="varchar(15)")]
        public string Valor { get; set; }
        //public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
