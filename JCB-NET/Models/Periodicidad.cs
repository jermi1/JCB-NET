using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JCB_NET.Models
{
    [Table("T_Periodicidad")]
    public class Periodicidad
    {
        [Key]
        [Column(TypeName = "tinyint")]
        public int Id_Periodicidad { get; set; }
        
        [Required] 
        [Column(TypeName = "varchar(20)")]
        public string Valor { get; set; }
    }
}
