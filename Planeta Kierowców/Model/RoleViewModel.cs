using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Planeta_Kierowców.Data;

namespace Planeta_Kierowców.Model
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {


        }

        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }




    }
}
