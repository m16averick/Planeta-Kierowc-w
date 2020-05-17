using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;


namespace Planeta_Kierowców.Pages.Zamówienia
{
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }



        [BindProperty]
        public order order { get; set; }
        public async Task OnGet(int id)
        {
            order = await _db.order.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var OrderFromDb = await _db.order.FindAsync(order.Id);
                OrderFromDb.Id = order.Id;
                OrderFromDb.Firma = order.Firma;
                OrderFromDb.Rodzaj = order.Rodzaj;
                OrderFromDb.Kierowca = order.Kierowca;
                

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}