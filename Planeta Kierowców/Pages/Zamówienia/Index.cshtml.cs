using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;


namespace Planeta_Kierowców.Pages.Zamówienia
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<order> orders { get; set; } 
        public async Task OnGet()
        {
            orders = await _db.order.ToListAsync();
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

            return RedirectToPage("Index");
        }
    }
}