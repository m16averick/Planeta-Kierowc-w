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

namespace Planeta_Kierowców.Pages.Administracja
{
    [Authorize(Roles = "Admin")]
    public class EditUserModel : PageModel
    {
        UserManager<ApplicationUser> userManager;
        private ApplicationDbContext _db;

        public EditUserModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser User { get; set; }
        public async Task OnGet(string id)
        {

            User = await _db.Users.FindAsync(id);
            // GetClaimsAsync retunrs the list of user Claims
            //var userClaims = await userManager.GetClaimsAsync(User);
            // GetRolesAsync returns the list of user Roles
            //var userRoles = await userManager.GetRolesAsync(User);

            var model = new EditUserViewModel
            {
                Id = User.Id,
                Email = User.Email,
                UserName = User.UserName,
                //Roles = userRoles
            };

        }


        public Task<IActionResult> OnPost()
        {

            return null;

        }
    }
}