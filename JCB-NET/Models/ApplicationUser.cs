using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(30)")]
        public string Nombres { get; set; }
        [Column(TypeName ="varchar(15)")]
        public string ApePaterno { get; set; }
        [Column(TypeName ="varchar(15)")]
        public string ApeMaterno { get; set; }
        [Column(TypeName ="varchar(80)")]
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        [Column(TypeName ="varchar(30)")]
        public string NroDocumento { get; set; }

        public int Id_TipoDocumento { get; set; }
        
        [ForeignKey("Id_TipoDocumento")]
        public virtual TipoDocumento TipoDocumento { get; set; }

    }
}
