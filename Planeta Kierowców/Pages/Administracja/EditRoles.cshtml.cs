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

    public class EditRolesModel : PageModel
    {

        private readonly RoleManager<IdentityRole> roleManager;


        private ApplicationDbContext _db;

        public EditRolesModel(ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            this.roleManager = roleManager;
        }

        public Model.UserRolesViewModel URVM { get; set; }
        public void OnGet(int id)
        {


        }

        public async Task<IActionResult> OnPost(string id)
        {

            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);


            return RedirectToPage("EditRoles");

        }
    }
}