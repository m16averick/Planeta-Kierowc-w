using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;

namespace Planeta_Kierowców.Pages.Zamówienia
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Zlecenia Zlecenia { get; set; }
        public async Task OnGet(int id)
        {
            Zlecenia = await _db.Zlecenia.FindAsync(id);

        }

        public async Task<IActionResult> OnPost()
        {
            Zlecenia.Koordynator_ID = User.Identity.GetUserId();
            if (true)
            {
                var OrderFromDb = await _db.Zlecenia.FindAsync(Zlecenia.ID_Zlecenie);
                OrderFromDb.ID_Zlecenie = Zlecenia.ID_Zlecenie;
                OrderFromDb.Miejsce_odbioru = Zlecenia.Miejsce_odbioru;
                OrderFromDb.Czas_odbioru = Zlecenia.Czas_odbioru;
                OrderFromDb.Miejsce_zdania = Zlecenia.Miejsce_zdania;
                OrderFromDb.Czas_zdania = Zlecenia.Czas_zdania;
                OrderFromDb.Status_zlecenia = Zlecenia.Status_zlecenia;
                OrderFromDb.Kierowca_ID = Zlecenia.Kierowca_ID;
                OrderFromDb.Koordynator_ID = Zlecenia.Koordynator_ID;

                await _db.SaveChangesAsync();

                return RedirectToPage("Details", new { id = Zlecenia.ID_Zlecenie });
            }
            return RedirectToPage();
        }
    }
}