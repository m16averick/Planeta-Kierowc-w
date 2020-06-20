using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Planeta_Kierowców.Model
{
    public class Protokoly
    {
        [Key]
        public int ID_Protokol { get; set; }


        [Required]
        [ForeignKey("Zlecenie_ID")]
        public int Zlecenie_ID { get; set; }

        [Required]
        public string filepath { get; set; }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
