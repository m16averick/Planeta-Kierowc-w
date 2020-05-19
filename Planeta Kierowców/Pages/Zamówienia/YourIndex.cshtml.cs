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



        public IEnumerable<order> orders { get; set; }
        public IEnumerable<order> orders2 { get; set; }
        public async Task OnGet(string tekst)
        {
            string currentUserId = User.Identity.GetUserId();
            orders = await _db.order.Where(s => s.Kierowca.Contains(currentUserId)).ToListAsync();



        }

        public async Task<IActionResult> OnPostDelete(int id)
        {

            var order = await _db.order.FindAsync(id);
            if (order==null)
            {
                return NotFound();
            }
            _db.order.Remove(order);
            await _db.SaveChangesAsync();

            return RedirectToPage("YourIndex");
        }
    }
}