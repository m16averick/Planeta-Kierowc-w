using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planeta_Kierowców.Model
{
    public class Zlecenia
    {
        [Key]
        public int ID_Zlecenie { get; set; }

        [Required]
        public string Miejsce_odbioru { get; set; }

        [Required]
        public DateTime Czas_odbioru { get; set; }

        [Required]
        public string Miejsce_zdania { get; set; }

        [Required]
        public DateTime Czas_zdania { get; set; }

        public string Status_zlecenia { get; set; }

        public string Kierowca_ID { get; set; }

        [Required]
        public string Koordynator_ID { get; set; }



    }
}
