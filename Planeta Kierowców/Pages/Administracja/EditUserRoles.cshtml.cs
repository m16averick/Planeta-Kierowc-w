using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Data;

namespace Planeta_Kierowców.Pages.Administracja
{

    public class EditUserRolesModel : PageModel
    {




        private ApplicationDbContext _db;

        public EditUserRolesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Model.UserRolesViewModel URVM { get; set; }
        public void OnGet(int id)
        {


        }


    }
}