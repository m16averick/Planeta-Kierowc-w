using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Planeta_Kierowców.Data;

namespace Planeta_Kierowców.Model
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {

            //var Claims = new List<string>();
            var AllRoles = new List<string>();
            var RoleArray = new List<Boolean>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

       //public string City { get; set; }


        public IList<string> AllRoles { get; set; }

        public bool[] RoleArrayModel { get; set; }



    }
}
