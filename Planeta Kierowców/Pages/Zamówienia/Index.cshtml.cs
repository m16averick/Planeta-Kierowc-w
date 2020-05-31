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

namespace Planeta_Kierowców.Pages.Zamówienia
{
    [Authorize(Roles="Admin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Zlecenia> orders { get; set; } 
        public async Task OnGet()
        {
            orders = await _db.Zlecenia.ToListAsync();
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

            return RedirectToPage("Index");
        }
    }
}