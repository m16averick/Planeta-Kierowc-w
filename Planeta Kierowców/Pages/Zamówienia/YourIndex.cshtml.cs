using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Planeta_Kierowców.Pages.Zamówienia
{
    [Authorize(Roles="Driver")]
    public class YourIndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public YourIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }



        public IEnumerable<Zlecenia> orders { get; set; }
        public IEnumerable<Zlecenia> orders2 { get; set; }
        public async Task OnGet(string tekst)
        {



            string currentUserId = User.Identity.GetUserId();
            string currentUserName = User.Identity.GetUserName();
            orders = await _db.Zlecenia.Where(s => s.Kierowca_ID.Contains(currentUserId)).ToListAsync();

            //sql injection

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {

            var order = await _db.Zlecenia.FindAsync(id);
            if (order==null)
            {
                return NotFound();
            }
            _db.Zlecenia.Remove(order);
            await _db.SaveChangesAsync();

            return RedirectToPage("YourIndex");
        }
    }
}