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
    public class EditUserModel : PageModel
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private ApplicationDbContext _db;
        public EditUserViewModel model;

        public EditUserModel(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [BindProperty]
        public ApplicationUser ApUser { get; set; }
        public ApplicationUser ApUser2 { get; set; }

        [BindProperty]
        public Boolean[] NewRoleArray { get; set; }


        public Boolean IsUserInARoleAsync(String Role, ApplicationUser User)
        {
            var userRoles = userManager.GetRolesAsync(User);
            if (userRoles.Result.Contains(Role)) return true;
            else return false;
        }
        public async Task OnGet(string id)
        {
            NewRoleArray = new bool[10];
            ApUser = await _db.Users.FindAsync(id);
            var userRoles = await userManager.GetRolesAsync(ApUser);




            var AllRoles = roleManager.Roles;


            List<String> RoleNames = new List<string>();
            foreach (var role in AllRoles)
            {
                RoleNames.Add(role.Name);

            }


            /*
                        List<Boolean> uRolesB = new List<Boolean>();
                        foreach (var role in Roles)
                        {
                            allRoles.Add(role.Name);
                            if (userRoles.Contains(role.Name)) uRolesB.Add(true);
                            else uRolesB.Add(false);
                        }
                        */
            // GetClaimsAsync retunrs the list of user Claims
            //var userClaims = await userManager.GetClaimsAsync(User);
            // GetRolesAsync returns the list of user Roles
            //var userRoles = await userManager.GetRolesAsync(User);

            model = new EditUserViewModel
            {
                Id = ApUser.Id,
                Email = ApUser.Email,
                UserName = ApUser.UserName,


                AllRoles = RoleNames
            };

        }


        public async Task<IActionResult> OnPost(string id)
        {

            ApUser2 = await _db.Users.FindAsync(id);

            var AllRoles = roleManager.Roles;



            List<String> RoleNames = new List<string>();
            foreach (var role in AllRoles)
            {
                RoleNames.Add(role.Name);

            }


            model = new EditUserViewModel
            {
                Email = ApUser.Email,
                UserName = ApUser.UserName,


            };

            ApUser2.UserName = model.UserName;
            ApUser2.Email = model.Email;



            _db.Users.Update(ApUser2);
            List<bool> FutureArray;
            FutureArray = new List<bool>();

            foreach (var Role in RoleNames)
            {

                if (Request.Form[Role].Count > 0)
                {
                    FutureArray.Add(true);
                }
                else
                {
                    FutureArray.Add(false);
                }
            }

            int i = 0;
            foreach (var Role in RoleNames)
            {
                if (FutureArray[i] && !IsUserInARoleAsync(Role, ApUser2) ) await userManager.AddToRoleAsync(ApUser2, Role);
                if (!FutureArray[i] && IsUserInARoleAsync(Role, ApUser2)) await userManager.RemoveFromRoleAsync(ApUser2, Role);
                i += 1;
            }
            
            await _db.SaveChangesAsync();
            return RedirectToPage("ListUsers");
        }
    }
}