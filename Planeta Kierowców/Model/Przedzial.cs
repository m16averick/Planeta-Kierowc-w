using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planeta_Kierowców.Model
{
    public class Przedzial
    {
        [Key]
        public int ID_Przedzial { get; set; }


        [Required]
        [ForeignKey("Kierowca_ID")]
        public string Kierowca_ID { get; set; }

        [Required]
        [ForeignKey("UserName")]
        public string UserName { get; set; }



        [Required]
        public DateTime Od { get; set; }

        [Required]
        public DateTime Do { get; set; }


    }
}
