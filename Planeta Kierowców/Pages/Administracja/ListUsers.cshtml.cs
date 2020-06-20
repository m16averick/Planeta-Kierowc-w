using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planeta_Kierowców.Data;
using Planeta_Kierowców.Model;



namespace Planeta_Kierowców.Pages.Administracja
{


    [Authorize(Roles = "Admin")]
    public class ListUsersModel : PageModel
    {
        UserManager<ApplicationUser> userManager;


        private readonly ApplicationDbContext _db;

        public ListUsersModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public ApplicationUser ApUser2 { get; set; }
        public IEnumerable<ApplicationUser> users { get; set; }


        public async Task<IActionResult> OnPost(string id)
        {
            ApUser2 = await _db.Users.FindAsync(id);

            _db.Users.Remove(ApUser2);
            await _db.SaveChangesAsync();
            return RedirectToPage("ListUsers");

        }

        public async Task OnGet()
        {
            users = await _db.Users.ToListAsync();
        }


        


    }
}