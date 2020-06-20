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

namespace Planeta_Kierowców.Pages.Administracja
{
    [Authorize(Roles = "Admin")]
    public class EditUserRolesModel : PageModel
    {
        UserManager<ApplicationUser> userManager;
        private ApplicationDbContext _db;
        public EditUserViewModel model;

        public EditUserRolesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser ApUser { get; set; }
        public ApplicationUser ApUser2 { get; set; }
        public async Task OnGet(string id)
        {

            ApUser = await _db.Users.FindAsync(id);
            // GetClaimsAsync retunrs the list of user Claims
            //var userClaims = await userManager.GetClaimsAsync(User);
            // GetRolesAsync returns the list of user Roles
            //var userRoles = await userManager.GetRolesAsync(User);

            model = new EditUserViewModel
            {
                Id = ApUser.Id,
                Email = ApUser.Email,
                UserName = ApUser.UserName,
                //Roles = userRoles
            };

        }


        public async Task<IActionResult> OnPost(string id)
        {
            ApUser2 = await _db.Users.FindAsync(id);
            // GetClaimsAsync retunrs the list of user Claims
            //var userClaims = await userManager.GetClaimsAsync(User);
            // GetRolesAsync returns the list of user Roles
            //var userRoles = await userManager.GetRolesAsync(User);

            model = new EditUserViewModel
            {
                Email = ApUser.Email,
                UserName = ApUser.UserName
                //Roles = userRoles
            };

            ApUser2.UserName = model.UserName;
            ApUser2.Email = model.Email;

            _db.Users.Update(ApUser2);
            await _db.SaveChangesAsync();
            return RedirectToPage("ListUsers");
        }
    }
}