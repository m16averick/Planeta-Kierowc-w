using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planeta_Kierowców.Model
{
    public class order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firma { get; set; }

        public int Rodzaj { get; set; }

        public string Kierowca { get; set; }



    }
}
