using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Data;
using Planeta_Kierowców.Model;
using System.Security.Claims;
using Microsoft.AspNet.Identity;


namespace Planeta_Kierowców.Pages.Zamówienia
{
    [Authorize(Roles = "Admin")]


    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty]
        public Zlecenia zlecenie { get; set; }

        public void OnGet()
        {
            string currentUserId = User.Identity.GetUserId();
            string currentUserName = User.Identity.GetUserName();
        }

        public async Task<IActionResult> OnPost()
        {
            zlecenie.Koordynator_ID = User.Identity.GetUserId();
            if (true)
            {
                await _db.Zlecenia.AddAsync(zlecenie);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            else
            {
                return Page();
            }
        }
    }
}