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
        public Zlecenia zlecenie { get; set; }
        public async Task OnGet(int id)
        {
            zlecenie = await _db.Zlecenia.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var OrderFromDb = await _db.Zlecenia.FindAsync(zlecenie.ID_Zlecenie);
                OrderFromDb.ID_Zlecenie = zlecenie.ID_Zlecenie;
                OrderFromDb.Miejsce_odbioru = zlecenie.Miejsce_odbioru;
                OrderFromDb.Czas_odbioru = zlecenie.Czas_odbioru;
                OrderFromDb.Miejsce_zdania = zlecenie.Miejsce_zdania;
                OrderFromDb.Czas_zdania = zlecenie.Czas_zdania;
                OrderFromDb.Status_zlecenia = zlecenie.Status_zlecenia;
                OrderFromDb.Kierowca_ID = zlecenie.Kierowca_ID;
                OrderFromDb.Koordynator_ID = zlecenie.Koordynator_ID;

                

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}