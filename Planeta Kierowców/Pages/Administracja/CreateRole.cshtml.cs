using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FluentAssertions.Common;
using System.Collections;

namespace Planeta_Kierowców.Pages.Administracja
{

    [Authorize(Roles = "Admin")]
    public class CreateRole : PageModel
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext _db;
        public RoleViewModel model;

        public CreateRole(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        [BindProperty]

        public RoleViewModel NowaRola { get; set; }





        public async Task OnGet(string id)
        {


        }


        public async Task<IActionResult> OnPost(string id)
        {









            model = new RoleViewModel
            {
                RoleName = NowaRola.RoleName
            };

            // creating Creating Employee role     
            bool x = await roleManager.RoleExistsAsync(NowaRola.RoleName);
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = NowaRola.RoleName;
                await roleManager.CreateAsync(role);
            }

            await _db.SaveChangesAsync();
            return RedirectToPage("EditRoles");
        }
    }
}